using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_Base
{
    public abstract void OnEnter();
    public abstract void OnStay();
    public abstract void OnExit();
}
