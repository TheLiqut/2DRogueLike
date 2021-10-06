using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public GameObject deadUI;
    public bool canRestart;
    [Header("对话")]
    public GameObject charPanel_Main;
    public DialogSystem dialog_Main;
    // Start is called before the first frame update
    public void Start()
    {
        Main_EventCenter.instance.onPlayerDead += ShowDead;
        Main_EventCenter.instance.onStartChat += StartChar;
        Main_EventCenter.instance.onStopChat += StopChar;
    }

    public void ShowDead()
    {
        deadUI.SetActive(true);
        canRestart = true;
    }

    public void StartChar(TextAsset _file)
    {
        dialog_Main.textFile = _file;
        charPanel_Main.SetActive(true);
    }

    public void StopChar()
    {
        charPanel_Main.SetActive(false);
    }
}
