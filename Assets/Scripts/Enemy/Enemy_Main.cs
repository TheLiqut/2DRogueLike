using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : Humanoid,ITakingDamage
{
    public Player_Main player;
    public float speed;
    public Transform targetTrans;
    public GameObject enemyShowUpEffect;
    public Rigidbody2D theRB;
    public bool traking;
    public bool atking;
    public bool canNotRotate;
    public bool antiTraking;
    public bool hurting;
    public bool isDead;
    public bool isWin;
    public int givePlayerExMin;
    public SpriteRenderer enemyImageBody;
    public bool canNotIntoHurtState;
    [Header("FSM")]
    private FSM_Controller fsm;
    private StateType stateType;
    public string currentStateShow;
    [Header("死亡后启用")]
    public List<GameObject> deathActive = new List<GameObject>();

    private void Awake()
    {
        fsm = new FSM_Controller();
        fsm.AddState(StateType.IDEL, new State_Idel(theAn,this,this.fsm));
        fsm.AddState(StateType.MOVE, new State_Move(theAn,this, this.fsm));
        fsm.AddState(StateType.ATK, new State_Attack(theAn, this, this.fsm));
        fsm.AddState(StateType.HURT, new State_Hurt(theAn,this, this.fsm));
        fsm.AddState(StateType.DEAD, new State_Death(theAn,this, this.fsm));

        fsm.SetState(StateType.IDEL);
    }
    void Start()
    {
        Main_EventCenter.instance.onPlayerDead += EnemyWin;
        player = Player_Main.instance;
        theRB = gameObject.GetComponent<Rigidbody2D>();
        targetTrans = player.transform;
        Instantiate(enemyShowUpEffect, transform.localPosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        fsm.OnStateStay();
    }
    void Update()
    {
        enemyImageBody.sortingOrder = -(int)transform.localPosition.y;
    }

    public void FaceToPlayer()
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
        if(isDead == false)
        {
            theHp -= _f;
            if(canNotIntoHurtState == false)
            {
                fsm.SetState(StateType.HURT);
            }

            if(theHp <= 0)
            {
                fsm.SetState(StateType.DEAD);
            }
        }
    }

    public void AN_to_Idel_State()
    {
        fsm.SetState(StateType.IDEL);
    }

    public void AN_to_Move_State()
    {
        fsm.SetState(StateType.MOVE);
    }

    public void AN_DeathEvent()
    {
        Main_EventCenter.instance.E_OnEnemyDead();
    }

    public void EnemyWin()
    {
        if(isDead == false)
        {
            isWin = true;
            fsm.SetState(StateType.IDEL);
        }
    }
}