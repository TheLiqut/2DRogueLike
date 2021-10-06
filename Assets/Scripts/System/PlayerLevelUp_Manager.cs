using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUp_Manager : MonoBehaviour
{
    public enum Direction { hp, atkPwr, shotSpd, shotPwr };
    public Direction upLevel;
    private Player_Main player;
    public Text upLevelText;
    public Text messageText;
    public Text price;
    public Text currentLevelText;
    public int priceInt;
    public bool canCheck;
    private bool started;
    public GameObject showInfo;
    public int maxLevel;

    void Start()
    {
        player = Player_Main.instance;
        messageText.text = " ";
    }

    private void Update()
    {
        if(started == false)
        {
            switch (upLevel)
            {
                case Direction.hp:
                    upLevelText.text = "提升生命值";
                    currentLevelText.text = player.theLevel_Hp.ToString();
                    price.text = priceInt.ToString();
                    started = true;
                    break;
                case Direction.atkPwr:
                    upLevelText.text = "提升攻击力";
                    currentLevelText.text = player.theLevel_AttackPower.ToString();
                    price.text = priceInt.ToString();
                    started = true;
                    break;
                case Direction.shotSpd:
                    upLevelText.text = "提升射击速度";
                    currentLevelText.text = player.theLevel_ShootSpeed.ToString();
                    price.text = priceInt.ToString();
                    started = true;
                    break;
                case Direction.shotPwr:
                    upLevelText.text = "升级远程武器";
                    currentLevelText.text = player.theLevel_ShootPower.ToString();
                    price.text = priceInt.ToString();
                    started = true;
                    break;
                default:
                    break;
            }
        }



        if (canCheck == true && Input.GetButtonDown("Check"))
        {
            switch (upLevel)
            {
                case Direction.hp:
                    if(player.playerEx >= priceInt)
                    {
                        if (player.theLevel_Hp < maxLevel)
                        {
                            player.playerEx -= priceInt;
                        player.theLevel_Hp += 1;
                        player.theHp += 1;
                        player.saver.Saver();
                        currentLevelText.text = player.theLevel_Hp.ToString();
                        Main_EventCenter.instance.E_OnPlayerExUp(-priceInt);
                        }
                        else if (player.theLevel_Hp == maxLevel)
                        {
                            messageText.text = "已满级";
                        }
                    }
                    else if((player.playerEx <= priceInt))
                    {
                        messageText.text = "经验值不足";
                    }
                    break;
                case Direction.atkPwr:
                    if (player.playerEx >= priceInt)
                    {
                        if (player.theLevel_AttackPower < maxLevel)
                        {
                            player.playerEx -= priceInt;
                            player.theLevel_AttackPower += 1;
                            player.saver.Saver();
                            currentLevelText.text = player.theLevel_AttackPower.ToString();
                            Main_EventCenter.instance.E_OnPlayerExUp(-priceInt);
                        }
                        else if(player.theLevel_AttackPower == maxLevel)
                        {
                            messageText.text = "已满级";
                        }
                    }
                    else if ((player.playerEx <= priceInt))
                    {
                        messageText.text = "经验值不足";
                    }
                    break;
                case Direction.shotSpd:
                    if (player.playerEx >= priceInt)
                    {
                        if (player.theLevel_ShootSpeed < maxLevel)
                        {
                            player.playerEx -= priceInt;
                            player.theLevel_ShootSpeed += 1;
                            player.FireRat -= 0.01f;
                            player.saver.Saver();
                            currentLevelText.text = player.theLevel_ShootSpeed.ToString();
                        
                        Main_EventCenter.instance.E_OnPlayerExUp(-priceInt);
                        }
                        else if (player.theLevel_ShootSpeed == maxLevel)
                        {
                            messageText.text = "已满级";
                        }
                    }
                    else if ((player.playerEx <= priceInt))
                    {
                        messageText.text = "经验值不足";
                    }
                    break;
                case Direction.shotPwr:
                    if (player.playerEx >= priceInt)
                    {
                        if (player.theLevel_ShootPower < maxLevel)
                        {
                        player.playerEx -= priceInt;
                        player.theLevel_ShootPower += 1;
                        player.saver.Saver();
                        currentLevelText.text = player.theLevel_ShootPower.ToString();
                        Main_EventCenter.instance.E_OnPlayerExUp(-priceInt);
                        }
                        else if (player.theLevel_ShootPower == maxLevel)
                        {
                            messageText.text = "已满级";
                        }
                    }
                    else if ((player.playerEx <= priceInt))
                    {
                        messageText.text = "经验值不足";
                    }
                    break;
                default:
                    break;
            }
        }
    }

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
            messageText.text = " ";
            canCheck = false;
            showInfo.SetActive(false);
        }
    }
}
