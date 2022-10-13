using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tracker : MonoBehaviour
{
    public Enemy_Main enemyMain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                enemyMain.traking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                enemyMain.traking = false;
        }
    }
}
