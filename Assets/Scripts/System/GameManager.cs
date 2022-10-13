using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("=====设置关卡=====")]
    [Range(1,3)]public int currentDifficulty;
    public float UpdateDelayTime;
    public bool enemySeted;
    public List<Transform> setPointList = new List<Transform>();
    public List<GameObject> enemyList_1 = new List<GameObject>();
    public List<GameObject> enemyList_2 = new List<GameObject>();
    public List<GameObject> enemyList_3 = new List<GameObject>();
    [Header("波数")]
    public List<GameObject> enemyRound1 = new List<GameObject>();
    public List<GameObject> enemyRound2 = new List<GameObject>();
    public List<GameObject> enemyRound3 = new List<GameObject>();
    [Header("波数状态")]
    public int currentRound = 1;
    public int enemyCount;
    [Header("其它")]
    public bool levelFinished;


    private void Start()
    {
        Main_EventCenter.instance.onEnemyTransUpdate += AddTransList;
        Main_EventCenter.instance.onEnemyDead += EnemyCountReduce;
        currentDifficulty = Player_Main.instance.playingDifficulty;
    }

    private void Update()
    {
        UpdateDelayTime -= Time.fixedDeltaTime;
        if (UpdateDelayTime <= 0 && enemySeted == false)
        {
            enemySeted = true;
            EnemySetRound1();
        }
    }

    public void AddTransList(Transform _t)
    {
        setPointList.Add(_t);
    }

    
    public void EnemySetRound1()
    {
        switch (currentDifficulty)
        {
            case 1:
                for (int i = 0; i < (setPointList.Count/3); i++)
                {
                    enemyRound1.Add(enemyList_1[Random.Range(0, enemyList_1.Count)]);
                }
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count/3)+ (setPointList.Count / 3)); i++)
                {
                    enemyRound2.Add(enemyList_1[Random.Range(0, enemyList_1.Count)]);
                }
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    enemyRound3.Add(enemyList_1[Random.Range(0, enemyList_1.Count)]);
                }

                for (int i = 0; i < enemyRound1.Count; i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 2:
                for (int i = 0; i < (setPointList.Count / 3); i++)
                {
                    enemyRound1.Add(enemyList_2[Random.Range(0, enemyList_2.Count)]);
                }
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count / 3) + (setPointList.Count / 3)); i++)
                {
                    enemyRound2.Add(enemyList_2[Random.Range(0, enemyList_2.Count)]);
                }
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    enemyRound3.Add(enemyList_2[Random.Range(0, enemyList_2.Count)]);
                }

                for (int i = 0; i < enemyRound1.Count; i++)
                {
                    Instantiate(enemyList_2[Random.Range(0, enemyList_2.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 3:
                for (int i = 0; i < (setPointList.Count / 3); i++)
                {
                    enemyRound1.Add(enemyList_3[Random.Range(0, enemyList_3.Count)]);
                }
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count / 3) + (setPointList.Count / 3)); i++)
                {
                    enemyRound2.Add(enemyList_3[Random.Range(0, enemyList_3.Count)]);
                }
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    enemyRound3.Add(enemyList_3[Random.Range(0, enemyList_3.Count)]);
                }

                for (int i = 0; i < enemyRound1.Count; i++)
                {
                    Instantiate(enemyList_3[Random.Range(0, enemyList_3.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            default:
                break;
        }
    }

    public void EnemySetRound2()
    {
        switch (currentDifficulty)
        {
            case 1:
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count / 3) + (setPointList.Count / 3)); i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 2:
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count / 3) + (setPointList.Count / 3)); i++)
                {
                    Instantiate(enemyList_2[Random.Range(0, enemyList_2.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 3:
                for (int i = (setPointList.Count / 3); i < ((setPointList.Count / 3) + (setPointList.Count / 3)); i++)
                {
                    Instantiate(enemyList_3[Random.Range(0, enemyList_3.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            default:
                for (int i = 0; i < enemyRound2.Count; i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
        }
    }

    public void EnemySetRound3()
    {
        switch (currentDifficulty)
        {
            case 1:
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 2:
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    Instantiate(enemyList_2[Random.Range(0, enemyList_2.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            case 3:
                for (int i = ((setPointList.Count / 3) + (setPointList.Count / 3)); i < setPointList.Count; i++)
                {
                    Instantiate(enemyList_3[Random.Range(0, enemyList_3.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
            default:
                for (int i = 0; i < enemyRound3.Count; i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                    enemyCount += 1;
                }
                break;
        }
    }

    public void currentLevelFinished()
    {
        levelFinished = true;
        Main_EventCenter.instance.E_OnLevelFinished();
    }

    public void EnemyCountReduce()
    {
        enemyCount -= 1;
        if (enemyCount <= 0)
        {
            currentRound += 1;
            if(currentRound == 2)
            {
                EnemySetRound2();
            }
            if(currentRound == 3)
            {
                EnemySetRound3();
            }
            if(currentRound > 3)
            {
                currentLevelFinished();
            }
        }
    }
    /*public void EnemySetRound2()
    {
        switch (currentDifficulty)
        {
            case 1:
                //Debug.Log("已判断");
                for (int i = (setPointList.Count / 3); i < setPointList.Count-(setPointList.Count / 3); i++)
                {
                    Debug.Log("已生成");
                    enemyRound2.Add(enemyList_1[Random.Range(0, enemyList_1.Count)]);
                    //Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                for (int i = 0; i < enemyRound2.Count; i++)
                {
                    Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                break;
            case 2:
                //Debug.Log("已判断");
                for (int i = (setPointList.Count / 3); i < setPointList.Count - (setPointList.Count / 3); i++)
                {
                    Debug.Log("已生成");
                    enemyRound2.Add(enemyList_2[Random.Range(0, enemyList_1.Count)]);
                    //Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                for (int i = 0; i < enemyRound2.Count; i++)
                {
                    Instantiate(enemyList_2[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                break;
            case 3:
                //Debug.Log("已判断");
                for (int i = (setPointList.Count / 3); i < setPointList.Count - (setPointList.Count / 3); i++)
                {
                    Debug.Log("已生成");
                    enemyRound2.Add(enemyList_3[Random.Range(0, enemyList_1.Count)]);
                    //Instantiate(enemyList_1[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                for (int i = 0; i < enemyRound2.Count; i++)
                {
                    Instantiate(enemyList_3[Random.Range(0, enemyList_1.Count)], setPointList[i].position, Quaternion.identity);
                }
                break;
            default:
                break;
        }
    }*/
}
