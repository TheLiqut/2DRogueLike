using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeState : MonoBehaviour
{
    public GameObject showInfo;
    public bool canCheck;
    [Header("切换的特殊状态")]
    public SpeState speState;
    public enum SpeState
    {
        none,
        killHeal,
        AutoHeal
    };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = true;
            showInfo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = false;
            showInfo.SetActive(false);
        }
    }

    void Update()
    {
        if (canCheck == true && Input.GetButtonDown("Check"))
        {
            switch (speState)
            {
                case SpeState.none:
                    Player_Main.instance.SpeStateSwitcher(1);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case SpeState.killHeal:
                    Player_Main.instance.SpeStateSwitcher(2);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case SpeState.AutoHeal:
                    Player_Main.instance.SpeStateSwitcher(3);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
