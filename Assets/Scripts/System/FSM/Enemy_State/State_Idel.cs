using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idel : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    public State_Idel(Animator _animator, Enemy_Main _enemy,FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        animator.Play("Idel" + enemy.selfID.ToString());
        enemy.currentStateShow = "静止";

        if (enemy.isWin == false)
        {
            if (enemy.theHp <= 0)
            {
                fsm.SetState(StateType.DEAD);
                return;
            }

            if (enemy.traking == true)
            {
                fsm.SetState(StateType.MOVE);
                return;
            }
            if (enemy.atking == true)
            {
                fsm.SetState(StateType.ATK);
                return;
            }
        }
    }
}
