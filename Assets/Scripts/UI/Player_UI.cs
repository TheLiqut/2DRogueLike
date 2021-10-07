using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    private Player_Main player;
    private bool started;
    public Text showHpText;
    public Text showExText;
    public bool fighting;
    private void OnEnable()
    {
        //showExText.text = player.playerEx.ToString();
    }
    void Start()
    {
        player = Player_Main.instance;
        Main_EventCenter.instance.onPlayerHurt += UpdatePlayerHp;
        Main_EventCenter.instance.onPlayerExUp += UpdatePlayerEx;
        //showExText.text = player.playerEx.ToString();
    }

    private void Update()
    {
        showHpText.text = player.theHp.ToString();
        if (started == false)
        {
            //showHpText.text = player.theHp.ToString();
            showExText.text = player.playerEx.ToString();
            started = true;
        }
    }

    public void UpdatePlayerHp(float _f)
    {
        showHpText.text = _f.ToString();
    }

    public void UpdatePlayerEx(int _i)
    {
        showExText.text = player.playerEx.ToString();
    }
}
