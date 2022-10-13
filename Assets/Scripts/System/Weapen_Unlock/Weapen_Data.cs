using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapens", menuName = "Weapens")]
public class Weapen_Data : ScriptableObject
{
    public List<aWeapen_Data> weapList = new List<aWeapen_Data>();
}
