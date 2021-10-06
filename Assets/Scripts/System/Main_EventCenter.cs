using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Main_EventCenter : MonoBehaviour
{
    public static Main_EventCenter instance;
    public event Action onPlayerDead;
    public event Action<float> onPlayerHurt;
    public event Action<int> onPlayerExUp;
    public event Action<TextAsset> onStartChat;
    public event Action onStopChat;
    public event Action onStartResting;
    public event Action<Transform> onEnemyTransUpdate;
    public event Action onEnemyDead;
    public event Action onLevelFinished;

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
        //DontDestroyOnLoad(gameObject);
    }
    public void E_OnPlayerDead()//玩家死亡事件通知
    {
        if (onPlayerDead != null)
        {
            onPlayerDead();
        }
    }

    public void E_OnEnemyDead()//敌人死亡事件通知
    {
        if (onEnemyDead != null)
        {
            onEnemyDead();
        }
    }

    public void E_OnLevelFinished()//关卡完成事件通知
    {
        if (onLevelFinished != null)
        {
            onLevelFinished();
        }
    }

    public void E_OnPlayerHurt(float _f)//玩家受伤事件通知
    {
        if (onPlayerHurt != null)
        {
            onPlayerHurt(_f);
        }
    }

    public void E_OnPlayerExUp(int _i)//玩家获得经验值事件通知
    {
        if (onPlayerExUp != null)
        {
            onPlayerExUp(_i);
        }
    }

    public void E_OnStartChat(TextAsset _file)//开始对话事件通知
    {
        if (onStartChat != null)
        {
            onStartChat(_file);
        }
    }

    public void E_OnEnemyTransUpdate(Transform _t)
    {
        if (onEnemyTransUpdate != null)
        {
            onEnemyTransUpdate(_t);
        }
    }

    public void E_OnStopChat()//停止对话事件通知
    {
        if (onStopChat != null)
        {
            onStopChat();
        }
    }

    public void E_OnResting()//休息事件通知
    {
        if (onStartResting != null)
        {
            onStartResting();
        }
    }
}
