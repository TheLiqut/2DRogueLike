using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager_WeapenList : MonoBehaviour
{
    public Weapen_Checker checker;
    public void SaveWeapenList()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/_Weapen"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/_Weapen");
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/_Weapen/SaveWeapen.json");
        var json = JsonUtility.ToJson(checker.weapenData);
        //Debug.Log(json);
        formatter.Serialize(file, json);
        file.Close();
    }

    public void LoadWeapenList()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/_Weapen/SaveWeapen.json"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/_Weapen/SaveWeapen.json",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), checker.weapenData);
            file.Close();
        }
    }
}
