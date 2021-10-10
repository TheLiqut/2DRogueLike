using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject showInfo;
    public bool canCheck;
    public enum WeapenMod
    {
        com,
        randomShotGun,
        ringGun
    };
    [Header("切换的武器模式")]
    public WeapenMod weapenMod;


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
            switch (weapenMod)
            {
                case WeapenMod.com:
                    Player_Main.instance.GunWeapenSwitcher(1);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case WeapenMod.randomShotGun:
                    Player_Main.instance.GunWeapenSwitcher(2);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                case WeapenMod.ringGun:
                    Player_Main.instance.GunWeapenSwitcher(3);
                    canCheck = false;
                    showInfo.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
