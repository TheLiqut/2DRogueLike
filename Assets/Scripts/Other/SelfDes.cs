using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDes : MonoBehaviour
{
    public bool isTimerDes;
    public float desTime;

    private void FixedUpdate()
    {
        if(isTimerDes == true)
        {
            desTime -= Time.deltaTime;
            if (desTime <= 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
    public void AN_DesSelf()
    {
        GameObject.Destroy(gameObject);
    }
}
