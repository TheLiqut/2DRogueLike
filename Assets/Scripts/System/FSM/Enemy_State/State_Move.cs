using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Move : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    public State_Move(Animator _animator, Enemy_Main _enemy, FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        enemy.currentStateShow = "移动";
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        enemy.FaceToPlayer();
        if (enemy.hurting == false)
        {
            animator.Play("Run" + enemy.selfID.ToString());
            enemy.currentStateShow = "移动";
        }
        enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, enemy.targetTrans.position, enemy.speed * Time.deltaTime);

        if(enemy.isWin == true)
        {
            fsm.SetState(StateType.IDEL);
            return;
        }
        if (enemy.theHp <= 0)
        {
            fsm.SetState(StateType.DEAD);
            return;
        }
        if(enemy.atking == true)
        {
            fsm.SetState(StateType.ATK);
            return;
        }
        if(enemy.traking == false)
        {
            fsm.SetState(StateType.IDEL);
            return;
        }
    }
}
