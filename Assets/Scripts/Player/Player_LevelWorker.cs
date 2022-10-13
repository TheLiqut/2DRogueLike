using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelWorker : MonoBehaviour
{
    public Player_Main player;
    private bool started;

    void Update()
    {
        if(started == false)
        {
            Debug.Log(player.theLevel_Hp);
            player.theHp += player.theLevel_Hp;
            started = true;
        }
    }
}
