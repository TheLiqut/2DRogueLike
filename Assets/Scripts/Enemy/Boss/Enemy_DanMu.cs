using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DanMu : MonoBehaviour
{
    public Enemy_Main enemy;
    public float toPhase2Line;
    public GameObject bossBullet;
    public float firePower;
    public int fire1Round;
    public List<Transform> fireRound2List = new List<Transform>();
    public int fire2Round;
    public int fire2Round2;
    public int fireMod;


    public void AN_BossFire()
    {
        switch (fireMod)
        {
            case 1:
                StartCoroutine(Fire1());
                break;
            case 2:
                StartCoroutine(Fire2());
                break;
            default:
                StartCoroutine(Fire1());
                break;
        }
        
    }

    private void Update()
    {
        if(enemy.theHp <= toPhase2Line)
        {
            fireMod = 2;
        }
    }

    IEnumerator Fire1()
    {
        Vector3 Direction = this.transform.up;
        Quaternion startQuaternion = Quaternion.AngleAxis(360/fire1Round, Vector3.forward);

            for (int j = 0; j < fire1Round; j++)
            {
                GameObject bullet = Instantiate(bossBullet);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(Direction);
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bullet.transform.rotation.x,bullet.transform.rotation.y,bullet.transform.position.z)*firePower,ForceMode2D.Impulse);
                Direction = startQuaternion * Direction;
            }
            yield return new WaitForSeconds(0.5f);
            yield return null;
    }

    IEnumerator Fire2()
    {
        Vector3 Direction = this.transform.up;
        Quaternion startQuaternion = Quaternion.AngleAxis(360 / fire2Round, Vector3.forward);
        Quaternion secondsQuaternion = Quaternion.AngleAxis(360 / fire2Round2, Vector3.forward);

        for (int j = 0; j < fire2Round; j++)
        {
            GameObject bullet = Instantiate(bossBullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(Direction);
            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, bullet.transform.position.z) * firePower, ForceMode2D.Impulse);
            Direction = startQuaternion * Direction;
            fireRound2List.Add(bullet.transform);
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < fireRound2List.Count; i++)
        {
            if (fireRound2List[i] != null)
            {
                Vector3 Direction2 = fireRound2List[i].transform.up;
                for (int j = 0; j < fire2Round2; j++)
                {
                    GameObject bullet = Instantiate(bossBullet);
                    bullet.transform.position = fireRound2List[i].transform.position;
                    bullet.transform.rotation = Quaternion.Euler(Direction2);
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, bullet.transform.position.z) * firePower, ForceMode2D.Impulse);
                    Direction2 = secondsQuaternion * Direction2;
                }
            }  
        }
        fireRound2List.Clear();
        yield return new WaitForSeconds(0.5f);
        yield return null;
    }
}
