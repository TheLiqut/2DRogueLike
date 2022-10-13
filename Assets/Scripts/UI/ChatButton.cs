using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatButton : MonoBehaviour
{
    public bool startShow;
    public GameObject showInfo;
    public Text infoText;
    public string infoMain;
    [Header("对话文件")]
    //public TextAsset textFile;
    public List<TextAsset> textFiles = new List<TextAsset>();

    private void Start()
    {
        infoText.text = infoMain;
        Main_EventCenter.instance.onStopChat += ReturnShowInfo;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startShow = true;
            showInfo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startShow = false;
            showInfo.SetActive(false);
            Main_EventCenter.instance.E_OnStopChat();
        }
    }

    private void Update()
    {
        if (startShow == true && Input.GetButtonDown("Check"))
        {
            Main_EventCenter.instance.E_OnStartChat(textFiles[Global_GameManager.instance.usingLanguage]);
            showInfo.SetActive(false);
        }
    }

    public void ReturnShowInfo()
    {
        if (startShow == true)
        {
            showInfo.SetActive(true);
        }
    }
}
