using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpeState : MonoBehaviour
{
    public GameObject showInfo;
    public bool canCheck;
    public TextAsset thisSpeStateNameFile;
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
                    Global_GameManager.instance.speStateForPlayer = 0;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case SpeState.killHeal:
                    Global_GameManager.instance.speStateForPlayer = 1;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case SpeState.AutoHeal:
                    Global_GameManager.instance.speStateForPlayer = 2;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    public string GetSpeStateName()
    {
        var tempDate = thisSpeStateNameFile.text.Split('\n');
        string outString = tempDate[Global_GameManager.instance.usingLanguage];
        return outString;
    }
}
