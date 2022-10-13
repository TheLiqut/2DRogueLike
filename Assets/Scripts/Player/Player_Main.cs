using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Main : Humanoid,ITakingDamage
{
    public static Player_Main instance;
    [Header("=====属性=====")]
    public float sourceSpeed;
    public float speed;
    public float autoSpeed;
    public Rigidbody2D theRb;
    public Vector2 moveVec;
    public bool hurting;
    public bool isDead;
    public bool stopControl;//脱离控制角色
    [Header("=====其它=====")]
    public int playerEx;
    public string transSceneCode;
    [Range(1, 3)] public int playingDifficulty = 1;
    public bool canNotHit;
    public SaveManager saver;
    public SpriteRenderer playerImageBody;
    [Header("=====索敌=====")]
    public GameObject aimPointForEnemy;
    public GameObject enemySeeker;
    public bool startShooting;
    public Transform gunTrans;
    public GameObject targetEnemy;
    public Vector2 attackTarget;
    public GameObject targetMark;
    [Header("=====发射器=====")]
    public Player_WeapenShooter shooter;
    public string usingWeapenName;
    [Header("=====当前的武器模式=====")]
    public WeapenMod weapenMod;
    [Header("=====等级=====")]
    public int theLevel_Hp;
    [Header("=====特殊状态=====")]
    public SpeState speState;

    public enum WeapenMod
    {
        commGun,
        shotGun,
        ringGun
    };
    public enum SpeState
    {
        none,//=0
        killHeal,
        AutoHeal
    };
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
        if (moveVec.x == 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(stopControl == false)
        {
            MainController();//不脱离控制的情况下执行角色动作 
        }
        GunController();//自动瞄准敌人

        playerImageBody.sortingOrder = -(int)transform.localPosition.y;//改变角色图层
    }

    private void FixedUpdate()
    {
        if (stopControl == false)
        {
            MainMove();//不脱离控制的情况下移动角色
        }
    }

    public void MainMove()//移动角色
    {
            if (hurting != true)
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
    }

    public void MainController()//角色动作
    {
        if (isDead != true)
        {
            //玩家未死亡
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

            //=====

            startShooting = Input.GetButton("Attack");
            if(startShooting == true)
            {
                enemySeeker.SetActive(true);
            }
            else
            {
                enemySeeker.SetActive(false);
            }

            if (startShooting && hurting != true)
            {
                GunFire();
            }
        }
        else
        {
            bool deadChecked = false;
            //玩家死亡
            if (deadChecked == false)
            {
                Main_EventCenter.instance.E_OnPlayerDead();
                deadChecked = true;
            }
        }
    }

    public void GunController()//自动瞄准敌人
    {
        if(targetEnemy != null)
        {
            targetMark.SetActive(true);
            targetMark.transform.position = targetEnemy.transform.position;

            attackTarget.x = targetMark.transform.position.x;
            
            attackTarget.y = targetMark.transform.position.y - 0.75f;

            Vector2 lookDir = attackTarget - (Vector2)gunTrans.position;
            lookDir = lookDir.normalized;
            gunTrans.right = lookDir;
        }
        else
        {
            targetMark.SetActive(false);
        }
    }

    public void GunFire()//射击
    {
        switch (weapenMod)
        {
            case WeapenMod.commGun:
                shooter.CommGunFire();
                break;
            case WeapenMod.shotGun:
                shooter.ShotGunFire();
                break;
            case WeapenMod.ringGun:
                shooter.RingGunFire();
                break;
            default:
                break;
        }
        
    }

    public void GunWeapenSwitcher(int _i)//切换当前武器模式
    {
        switch (_i)
        {
            case 1:
                weapenMod = WeapenMod.commGun;
                break;
            case 2:
                weapenMod = WeapenMod.shotGun;
                break;
            case 3:
                weapenMod = WeapenMod.ringGun;
                break;
        }
    }

    public void TakeDamage(float _f)//承受伤害
    {
        if(canNotHit == false)
        {
            theAn.Play("Hurt" + selfID.ToString());
            theHp -= _f;
            Main_EventCenter.instance.E_OnPlayerHurt(theHp);
        }
    }

    public override void CheckDeath()//确认死亡
    {
        if (theHp <= 0)
        {
            Main_EventCenter.instance.E_OnPlayerDead();
            theAn.Play("Dead" + selfID.ToString());
        }
    }
}
