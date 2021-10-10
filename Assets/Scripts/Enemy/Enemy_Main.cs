using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : Humanoid,ITakingDamage
{
    public Player_Main player;
    public float speed;
    public Transform targetTrans;
    public GameObject enemyShowUpEffect;
    //public Rigidbody2D theRB;
    public bool traking;
    public bool canNotRotate;
    public bool attacking;
    public bool antiTraking;
    public bool hurting;
    public bool isDead;
    public bool isWin;
    public int givePlayerExMin,givePlayerExMax;
    public SpriteRenderer enemyImageBody;
    [Header("Boss")]
    public bool isFreezBoss;
    public bool isBoss;
    public GameObject playerWinPortal;
    public float phase2Line;
    public float sourcePhase2Line;
    public enum EnemyMod
    {
        com,
        dasher,
    };
    [Header("敌人模式")]
    public EnemyMod enemyMod;
    [Header("冲刺敌人")]
    public bool tracked;
    public bool speedUping;
    public bool moveMod;

    void Start()
    {
        Main_EventCenter.instance.onPlayerDead += EnemyWin;
        player = Player_Main.instance;
        targetTrans = player.transform;
        sourcePhase2Line = phase2Line;
        Instantiate(enemyShowUpEffect, transform.localPosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {
            
        switch (enemyMod)
        {
            case EnemyMod.com:
                Track_Player();
                break;
            case EnemyMod.dasher:
                Track_Player();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isDead != true && isWin != true)
        {
            CheckDeath();
            if(speedUping == false)
            {
                FaceToPlayer();
            }
            switch (enemyMod)
            {
                case EnemyMod.com:
                    ComAttackPlayer();
                    break;
                case EnemyMod.dasher:
                    DasherAttackPlayer();
                    break;
                default:
                    break;
            }
        }
        enemyImageBody.sortingOrder = -(int)transform.localPosition.y;
    }

    public void Track_Player()
    {
        if(isDead != true && isWin != true)
        {
            if (traking == true && hurting != true &&attacking !=true)
            {
                if(isFreezBoss == false && speedUping == false)
                {
                    theAn.Play("Run" + selfID.ToString());
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTrans.position, speed * Time.deltaTime);
                }
            }
            if (traking == true && antiTraking == true && hurting != true && attacking != true)
            {
                if(isFreezBoss == false)
                {
                    theAn.Play("Run" + selfID.ToString());
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTrans.position, -speed * Time.deltaTime);
                }
            }
            if (traking == false && hurting != true && attacking != true)
            {
                theAn.Play("Idel" + selfID.ToString());
            }
            if (hurting == true)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTrans.position, (-speed / 2) * Time.deltaTime);
            }
        }
    }

    public void ComAttackPlayer()
    {
        if (attacking == true && hurting != true)
        {
            //Debug.Log("inRange");
            theAn.Play("Attack" + selfID.ToString());
        }
    }

    public void DasherAttackPlayer()
    {
        if (attacking == true && hurting != true)
        {
            if(tracked == false)
            {
                if(moveMod == true)
                {
                    theAn.Play("Attack" + selfID.ToString());
                }
                else
                {
                    theAn.Play("JumpBack" + selfID.ToString());
                }
                tracked = true;
            }
        }
        if (speedUping == true)
        {
            if(moveMod == true)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTrans.position, (speed * 5) * Time.deltaTime);
            }
            if (moveMod == false)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetTrans.position, -(speed * 2.5f) * Time.deltaTime);
            }
        }
    }

    void FaceToPlayer()
    {
        if (transform.position.x < targetTrans.gameObject.transform.position.x)
        {
            if (canNotRotate != true)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }

        }
        if (transform.position.x > targetTrans.gameObject.transform.position.x)
        {
            if (canNotRotate != true)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
        }
    }

    public void TakeDamage(float _f)
    {
        if(isDead != true)
        {
            if(isFreezBoss == false)
            {
                theAn.Play("Hurt" + selfID.ToString());
                theHp -= _f;
            }
            else
            {
                phase2Line -= _f;
                theHp -= _f;
                if (phase2Line <= 0)
                {
                    theAn.Play("Hurt" + selfID.ToString());
                }
            }
        }
    }

    public override void CheckDeath()
    {
        if (theHp <= 0)
        {
            Main_EventCenter.instance.E_OnEnemyDead();
            theAn.Play("Dead" + selfID.ToString());
            int outPut = Random.Range(givePlayerExMin, givePlayerExMax);
            player.playerEx += outPut;
            Main_EventCenter.instance.E_OnPlayerExUp(outPut);
            player.saver.Saver();
            if(isBoss == true)
            {
                if (playerWinPortal != null)
                {
                    playerWinPortal.SetActive(true);
                }
            }
        }
    }

    public void EnemyWin()
    {
        if(isDead == false)
        {
            isWin = true;
            theAn.Play("Idel" + selfID.ToString());
        }
    }

    public void AN_Phase2LineReturn()
    {
        phase2Line = sourcePhase2Line;
    }

    public void AN_ChangeDashMod()
    {
        int temp = Random.Range(0, 3);
        if (temp == 0|| temp == 1)
        {
            moveMod = true;
        }
        if (temp == 2)
        {
            moveMod = false;
        }
    }
}
