using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempRespaw : MonoBehaviour
{
    public string RespawSceneName;

    public void AN_RespawScene()
    {
        SceneManager.LoadScene(0);
    }
    public void AN_ResetPlayer()
    {
        Player_Main.instance.theHp = 10 + Player_Main.instance.theLevel_Hp;
        Player_Main.instance.transform.position = new Vector3(0, 0, 0);
        Player_Main.instance.isDead = false;
    }
}
