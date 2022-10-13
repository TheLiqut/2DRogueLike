using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Death : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    public State_Death(Animator _animator, Enemy_Main _enemy, FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        for (int i = 0; i < enemy.deathActive.Count; i++)
        {
            enemy.deathActive[i].SetActive(true);
        }
        Player_Main.instance.playerEx += enemy.givePlayerExMin;
        Player_Main.instance.saver.Saver();

        //玩家特殊状态-击杀恢复
        if(Global_GameManager.instance.speStateForPlayer == 1 &&
          Player_Main.instance.theHp < (10 + Player_Main.instance.theLevel_Hp))
        {
            Player_Main.instance.theHp += 1;
        }
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
        animator.Play("Dead" + enemy.selfID.ToString());
        enemy.currentStateShow = "死亡";
    }
}
