using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnterPoint : MonoBehaviour
{
    public string enterPointCode;
    public GameObject BlkOutProject;

    void Start()
    {
        BlkOutProject.SetActive(true);
        if (Player_Main.instance.transSceneCode == enterPointCode)
        {
            Player_Main.instance.transform.position = transform.position;
        }
    }
}
