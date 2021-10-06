using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : Humanoid,ITakingDamage
{
    [Header("属性")]
    public static Player_Main instance;
    public float speed;
    public float attackSpeed;
    public Rigidbody2D theRb;
    public Vector2 moveVec;
    private float lastX;
    private float lastY;
    public bool attacking;
    public bool hurting;
    public bool speedUp;
    public bool isDead;
    private bool deadChecked;
    [Header("其它")]
    public int playerEx;
    public string transSceneCode;
    [Range(1, 3)] public int playingDifficulty = 1;
    public bool canNotHit;
    public SaveManager saver;
    public SpriteRenderer playerImageBody;
    [Header("索敌")]
    public GameObject aimPointForEnemy;
    public GameObject enemySeeker;
    public bool startShooting;
    public Transform gunTrans;
    public GameObject targetEnemy;
    public Vector2 attackTarget;
    public GameObject targetMark;
    [Header("武器面板")]
    public GameObject playerBullet;
    public int bulletNum;
    //public Transform fireTrans;
    public Transform fireTrans;
    public float gunSight;
    public float firePower;
    public float FireRat;
    public float sourceFireRat;
    private float timer;
    [Header("等级")]
    public int theLevel_Hp;
    public int theLevel_ShootSpeed;
    public int theLevel_ShootPower;
    public int theLevel_AttackPower;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        lastX = moveVec.x;
        lastY = moveVec.y;
        if (moveVec.x == 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        attackSpeed = speed * 7;
        sourceFireRat = FireRat;
    }

    // Update is called once per frame
    void Update()
    {
        MainController();
        GunController();
        playerImageBody.sortingOrder = -(int)transform.localPosition.y;
    }

    private void FixedUpdate()
    {
        MainMove();
    }

    public void MainMove()
    {
            if (attacking == false && hurting != true)
            {
                theRb.MovePosition(theRb.position + moveVec * speed * Time.fixedDeltaTime);
                if (moveVec.x != 0 || moveVec.y != 0)
                {
                    theAn.Play("Move" + selfID.ToString());
                }
                if (moveVec.x == 0 && moveVec.y == 0)
                {
                    theAn.Play("Idel" + selfID.ToString());
                }
            }
        
        if(speedUp == true)
        {
            theRb.MovePosition(theRb.position + new Vector2(lastX,lastY) * attackSpeed * Time.fixedDeltaTime);
        }
    }

    public void MainController()
    {
        if (isDead != true)
        {
            CheckDeath();
            moveVec.x = Input.GetAxisRaw("Horizontal");
            moveVec.y = Input.GetAxisRaw("Vertical");
            if (moveVec.x > 0)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            if (moveVec.x < 0)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }

            if (Input.GetButtonDown("Attack") && hurting != true)
            {
                lastX = moveVec.x;
                lastY = moveVec.y;
                theAn.Play("Attack" + selfID.ToString());
            }

            startShooting = Input.GetButton("Attack2");
            if(startShooting == true)
            {
                enemySeeker.SetActive(true);
            }
            else
            {
                enemySeeker.SetActive(false);
            }
            if (Input.GetButton("Attack2") && hurting != true)
            {
                GunFire();
            }
        }
        else
        {
            if (deadChecked == false)
            {
                Main_EventCenter.instance.E_OnPlayerDead();
                deadChecked = true;
            }
        }
    }

    public void GunController()
    {
        if(targetEnemy != null)
        {
            targetMark.SetActive(true);
            targetMark.transform.position = targetEnemy.transform.position;
            attackTarget.x = targetMark.transform.position.x;
            attackTarget.y = targetMark.transform.position.y;
            Vector2 lookDir = attackTarget - (Vector2)gunTrans.position;
            lookDir = lookDir.normalized;
            gunTrans.right = lookDir;
        }
        else
        {
            targetMark.SetActive(false);
        }
    }

    public void GunFire()
    {
        if(targetEnemy != null)
        {
            timer += Time.deltaTime;
            if (timer > FireRat)
            {
                timer = 0;
                GameObject bullet = Instantiate(playerBullet, fireTrans.position, fireTrans.rotation * Quaternion.AngleAxis(Random.Range(0, gunSight), Vector3.forward));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * firePower, ForceMode2D.Impulse);
            }
        }
    }

    public void AN_ResetLastMoveVec()
    {
        lastX = 0;
        lastY = 0;
    }

    public void TakeDamage(float _f)
    {
        if(canNotHit == false)
        {
            theAn.Play("Hurt" + selfID.ToString());
            theHp -= _f;
            Main_EventCenter.instance.E_OnPlayerHurt(theHp);
        }
    }

    public override void CheckDeath()
    {
        if (theHp <= 0)
        {
            Main_EventCenter.instance.E_OnPlayerDead();
            theAn.Play("Dead" + selfID.ToString());
        }
    }
}
