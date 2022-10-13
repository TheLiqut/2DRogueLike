using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSeter : MonoBehaviour
{
    public TextAsset fileMain;
    public Text textMain;

    private void Start()
    {
        var tempDate = fileMain.text.Split('\n');
        textMain.text = tempDate[Global_GameManager.instance.usingLanguage];
    }
}
