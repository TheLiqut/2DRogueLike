using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_UI : MonoBehaviour
{
    public Enemy_Main enemy;
    public Image fillImg;
    public float theFillNum;

    private void Start()
    {
        theFillNum = 1 / enemy.theHp;
    }
    private void Update()
    {
        fillImg.fillAmount = enemy.theHp * theFillNum;
    }
}
