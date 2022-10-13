using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    private Player_Main player;
    public Text showHpText;
    public Text showExText;
    public Text showWpText;
    public Text showSpeText;
    public bool fighting;
    private void OnEnable()
    {
        //showExText.text = player.playerEx.ToString();
    }
    void Start()
    {
        player = Player_Main.instance;
    }
    private void FixedUpdate()
    {
        showHpText.text = player.theHp.ToString();
        showExText.text = player.playerEx.ToString();
        showWpText.text = player.usingWeapenName;
        showSpeText.text = Global_GameManager.instance.speStateForPlayer_Now;
    }
}
