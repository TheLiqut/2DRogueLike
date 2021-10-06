using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelWorker : MonoBehaviour
{
    public Player_Main player;
    private bool started;
    public List<GameObject> bulletUpdateList = new List<GameObject>();

    void Update()
    {
        if(started == false)
        {
            Debug.Log(player.theLevel_Hp);
            player.theHp += player.theLevel_Hp;
            player.FireRat -= player.theLevel_ShootSpeed * 0.01f;
            started = true;
        }
        player.playerBullet = bulletUpdateList[player.theLevel_ShootPower];
    }
}
