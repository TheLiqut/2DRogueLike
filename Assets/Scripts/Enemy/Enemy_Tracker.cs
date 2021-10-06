using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tracker : MonoBehaviour
{
    public Enemy_Main enemyMain;
    public bool range_Atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(range_Atk == true)
            {
                enemyMain.traking = true;
            }
            else
            {
                enemyMain.attacking = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (range_Atk == true)
            {
                enemyMain.traking = false;
            }
            else
            {
                enemyMain.attacking = false;
            }
        }
    }
}
