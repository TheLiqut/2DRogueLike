using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoomNear : MonoBehaviour
{
    public GameObject Blocker;
    public bool have;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid"))
        {
            have = true;
            Blocker.SetActive(false);
        }
    }
}
