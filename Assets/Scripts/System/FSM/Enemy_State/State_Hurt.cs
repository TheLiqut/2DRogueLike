using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Hurt : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    public State_Hurt(Animator _animator, Enemy_Main _enemy, FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        if (enemy.theHp <= 0)
        {
            fsm.SetState(StateType.DEAD);
        } 
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        animator.Play("Hurt" + enemy.selfID.ToString());
        enemy.currentStateShow = "受伤";
    }
}
