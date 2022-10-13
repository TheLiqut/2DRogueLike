using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    private Player_Main player;

    private void Start()
    {
        player = Player_Main.instance;
        Loader();
    }
    //保存游戏
    private Save StartSave()
    {
        Save save = new Save();
        save.Ex = player.playerEx;
        save.Level_Hp = player.theLevel_Hp;
       // save.Level_AttackPower = player.theLevel_AttackPower;
        //save.Level_ShootSpeed = player.theLevel_ShootSpeed;
        //save.Level_ShootPower = player.theLevel_ShootPower;

        return save;
    }

    //保存文件
    public void Saver()
    {
        Save save = StartSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/SaveByBin.txt");
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }

    //读取
    public void Loader()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveByBin.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/SaveByBin.txt", FileMode.Open);
            Save save = (Save)bf.Deserialize(fileStream);
            fileStream.Close();
            Open(save);
        }
    }
    private void Open(Save save)
    {
        player.playerEx = save.Ex;
        player.theLevel_Hp = save.Level_Hp;
        //player.theLevel_AttackPower = save.Level_AttackPower;
        //player.theLevel_ShootSpeed = save.Level_ShootSpeed;
        //player.theLevel_ShootPower = save.Level_ShootPower;
    }
}
