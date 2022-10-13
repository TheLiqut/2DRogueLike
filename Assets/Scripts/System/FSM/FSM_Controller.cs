using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    IDEL,
    MOVE,
    ATK,
    HURT,
    DEAD,
}
public class FSM_Controller
{
    private State_Base current_State;
    public StateType stateType;
    private Dictionary<StateType, State_Base> allSaveState;

    public FSM_Controller()
    {
        allSaveState = new Dictionary<StateType, State_Base>();
    }

    public void OnStateStay()
    {
        current_State?.OnStay();
    }

    public void AddState(StateType type,State_Base state)
    {
        if (allSaveState.ContainsKey(type))
        {
            return;
        }
        allSaveState.Add(type, state);
    }

    public void SetState(StateType type)
    {
        if (current_State == allSaveState[type])
        {
            return;
        }

        current_State?.OnExit();
        current_State = allSaveState[type];
        current_State.OnEnter();
    }
}
