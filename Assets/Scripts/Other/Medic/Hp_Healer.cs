using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Healer : MonoBehaviour
{
    public float healNum;
    private bool canHeal;
    public GameObject showUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canHeal = true;
        showUI.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canHeal = false;
        showUI.SetActive(false);
    }

    private void Update()
    {
        if(canHeal == true && Input.GetButtonDown("Check"))
        {
            showUI.SetActive(false);
            Player_Main.instance.theHp = 10 + Player_Main.instance.theLevel_Hp;
            this.gameObject.SetActive(false);
        }
    }
}
