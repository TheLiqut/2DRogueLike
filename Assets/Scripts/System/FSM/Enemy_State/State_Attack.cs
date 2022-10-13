using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Attack : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    public State_Attack(Animator _animator, Enemy_Main _enemy, FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        enemy.theRB.bodyType = RigidbodyType2D.Static;
    }

    public override void OnExit()
    {
        enemy.theRB.bodyType = RigidbodyType2D.Dynamic;
    }

    public override void OnStay()
    {
        animator.Play("Attack" + enemy.selfID.ToString());
        enemy.currentStateShow = "攻击";

        if (enemy.theHp <= 0)
        {
            fsm.SetState(StateType.DEAD);
            return;
        }
        if(enemy.traking == false)
        {
            fsm.SetState(StateType.IDEL);
            return;
        }
    }
}
