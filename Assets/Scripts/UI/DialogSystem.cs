using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("对话组件")]
    public Text charText;
    //public Image faceImage;
    public float showTextSpeed;
    public bool textFinished = true;
    public bool cancelText;
    [Header("对话文件")]
    public TextAsset textFile;
    public int textIndex;

    List<string> textList = new List<string>();
    private void OnEnable()
    {
        GetFileList(textFile);
        StartCoroutine(SetTextUI());
        //charText.text = textList[textIndex];
        //textIndex++;
    }
    private void Update()
    {
        ShowText();
    }
    public void GetFileList(TextAsset _textAsset)
    {
        textList.Clear();
        textIndex = 0;

        var tempDate = _textAsset.text.Split('\n');
        for (int i = 0; i < tempDate.Length; i++)
        {
            textList.Add(tempDate[i]);
        }
    }

    public void ShowText()
    {
        if (Input.GetButtonDown("Check"))
        {
            if (textFinished && !cancelText)
            {
                StartCoroutine(SetTextUI());
                //charText.text = textList[textIndex];
                //textIndex++;
            }
            else if (!textFinished)
            {
                cancelText = !cancelText;
            }
        }

        if (Input.GetButtonDown("Check") && textIndex == textList.Count - 1)
        {
            Main_EventCenter.instance.E_OnStopChat();
            textIndex = 0;
            gameObject.SetActive(false);
            return;
        }

    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        charText.text = "";
        //Debug.Log(textList[textIndex]);
        switch (textList[textIndex].Trim())
        {
            case "A":
                Player_Main.instance.playingDifficulty = 1;
                textIndex++;
                break;
            case "B":
                Player_Main.instance.playingDifficulty = 2;
                textIndex++;
                break;
            case "C":
                Player_Main.instance.playingDifficulty = 3;
                textIndex++;
                break;
            case "D":
                
                textIndex++;
                break;
            case "E":
                
                textIndex++;
                break;
            default:
                
                break;
        }
        /*for (int i = 0; i < textList[textIndex].Length; i++)
        {
            charText.text += textList[textIndex][i];
            yield return new WaitForSeconds(showTextSpeed);
        }*/
        int i = 0;
        while (!cancelText && i < textList[textIndex].Length - 1)
        {
            charText.text += textList[textIndex][i];
            i++;
            yield return new WaitForSeconds(showTextSpeed);
        }
        charText.text = textList[textIndex];
        cancelText = false;
        textIndex++;
        textFinished = true;
    }
}
