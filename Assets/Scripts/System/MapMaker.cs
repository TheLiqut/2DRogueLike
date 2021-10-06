using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapMaker : MonoBehaviour
{
    public static MapMaker instance;
    public enum Direction {up,down,left,right};
    public Direction direction;

    public List<GameObject> gridList = new List<GameObject>();
    public float xPosition;
    public float yPosition;
    public Transform startMakePoint;

    //public GameObject lastMake;
    public List<GameObject> lastTrans = new List<GameObject>();

    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }
    private void Start()
    {
        RandomGrid(gridList);
        for (int i = 0; i < instance.gridList.Count; i++)
        {
            instance.lastTrans.Add(Instantiate(gridList[i], startMakePoint.position, Quaternion.identity));
            instance.lastTrans[i].transform.SetParent(instance.startMakePoint.transform, false);
            RoomRandomPos(gridList[i]);
        }
        startMakePoint.transform.position = new Vector3(0, 0, 0);
    }

    private List<GameObject> RandomGrid(List<GameObject> myList)
    {

        System.Random ran = new System.Random();
        List<GameObject> newList = new List<GameObject>();
        int index = 0;
        GameObject temp;
        for (int i = 1; i < myList.Count-1; i++)
        {

            index = ran.Next(1, myList.Count - 1);
            if (index != i)
            {
                temp = myList[i];
                myList[i] = myList[index];
                myList[index] = temp;
            }
        }
        return myList;
    }

    public void RoomRandomPos(GameObject _lastMake)
    {
        Transform tempTrans = startMakePoint;
                direction = (Direction)UnityEngine.Random.Range(0, 4);
                switch (direction)
                {
                    case Direction.up:
                         tempTrans.position += new Vector3(0, yPosition, 0);
                        break;
                    case Direction.down:
                         tempTrans.position += new Vector3(0, -yPosition, 0);
                        break;
                    case Direction.left:
                         tempTrans.position += new Vector3(-xPosition, 0, 0);
                        break;
                    case Direction.right:
                         tempTrans.position += new Vector3(xPosition, 0, 0);
                        break;
                }
        for (int i = 0; i < lastTrans.Count; i++)
        {
            Debug.Log("Work1");
            if (lastTrans[i].transform.localPosition == tempTrans.localPosition)
            {
                Debug.Log("Work");
                RoomRandomPos(_lastMake);
                break;
            }
        }
        startMakePoint = tempTrans;
    }
}
