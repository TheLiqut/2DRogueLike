using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HurtColl : MonoBehaviour
{
    public float attackPower;
    public bool isBullet;
    public GameObject hitEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (isBullet == false)
            {
                if (collision.CompareTag("Player"))
                {
                    collision.GetComponent<Player_Main>().TakeDamage(attackPower);
                }
            }
            else
            {
                if (collision.CompareTag("Player"))
                {
                    collision.GetComponent<Player_Main>().TakeDamage(attackPower);
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                }
                if (!collision.CompareTag("Player"))
                {
                    Instantiate(hitEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
}
