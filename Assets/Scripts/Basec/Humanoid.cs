using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour
{
    public int selfID;
    public float theHp;
    public Animator theAn;

    public virtual void CheckDeath()
    {
        if (theHp <= 0)
        {
            theAn.Play("Dead"+selfID.ToString());
        }
    }
}
