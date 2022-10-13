using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_GameManager : MonoBehaviour
{
    public static Global_GameManager instance;
    public string speStateForPlayer_Now;
    public int speStateForPlayer;
    [Header("0-中文，1-英文")]
    public int usingLanguage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        SpeStateForPlayer();
    }

    public void SpeStateForPlayer()
    {
        switch (speStateForPlayer)
        {
            case 0 :
                
                break;
            case 1://击杀恢复

                //位于敌人State_Death

                break;
            case 2://自动恢复
                if (Player_Main.instance.theHp < (10 + Player_Main.instance.theLevel_Hp))
                {
                    Player_Main.instance.theHp += (0.1f * Time.deltaTime);
                }
                break;
            default:
                break;
        }
    }
}
