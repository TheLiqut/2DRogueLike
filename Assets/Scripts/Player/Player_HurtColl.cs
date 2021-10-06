using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HurtColl : MonoBehaviour
{
    public float attackPower;
    private bool started;
    public bool isBullet;
    public GameObject hitEffect;

    private void Update()
    {
        if (isBullet != true)
        {
            attackPower = 1+(Player_Main.instance.theLevel_AttackPower * 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isBullet == false)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy_Main>().TakeDamage(attackPower);
            }
        }
        else
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy_Main>().TakeDamage(attackPower);
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (!collision.CompareTag("Enemy"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
