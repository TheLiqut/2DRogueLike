using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySeter : MonoBehaviour
{
    public List<Transform> Front_setPointList = new List<Transform>();

    private void Start()
    {
        FreshTransformList(Front_setPointList);
        UpdateEnemyTrans();
    }

    private List<Transform> FreshTransformList(List<Transform> myList)
    {
        Debug.Log("已刷新");
        System.Random ran = new System.Random();
        List<Transform> newList = new List<Transform>();
        int index = 0;
        Transform temp;
        for (int i = 0; i < myList.Count; i++)
        {

            index = ran.Next(0, myList.Count - 1);
            if (index != i)
            {
                temp = myList[i];
                myList[i] = myList[index];
                myList[index] = temp;
            }
        }
        return myList;
    }
    public void UpdateEnemyTrans()
    {
        for (int i = 0; i < Front_setPointList.Count; i++)
        {
            Debug.Log("已传递");
            Main_EventCenter.instance.E_OnEnemyTransUpdate(Front_setPointList[i]);
        }
    }
}
