using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "aWeapen", menuName = "aSavePoint/The_aWeapen")]
public class Weapen_Data_Base : ScriptableObject
{
    public aWeapen_Data weapenData;
}
[Serializable]
public class aWeapen_Data
{
    [Header("武器名字")]
    public List<string> weapenName = new List<string>();
    public TextAsset weapNameFileMain;
    [Header("武器信息")]
    public List<string> weapenInfo = new List<string>();
    public TextAsset weapInfoFileMain;
    [Header("武器ID")]
    public int weapenID;
    [Header("武器类型0-普通,1-散射,2-环形")]
    [Range(0,2)]
    public int weapenType;
    //[Header("子弹ID")]
    //public int bulletID;
    [Header("精准度")]
    public float _gunSight;
    [Header("弹射速度")]
    public float _firePower;
    [Header("射击间隔")]
    public float _FireRat;
    [Header("散射子弹数")]
    public int _shotGunBulletNum;
    [Header("价格")]
    public int _weapenPrice;
    [Header("子弹")]
    public GameObject _bullet;
    [Header("已解锁？")]
    public bool _unLocked;
}
