using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WeapenShooter : MonoBehaviour
{
    [Header("玩家")]
    public Player_Main player;
    [Header("武器面板")]
    public GameObject playerBullet;
    //public GameObject playerRingBullet;
    //public int bulletNum;
    //public Transform fireTrans;
    public Transform fireTrans;
    public float gunSight;
    public float firePower;
    public float FireRat;
    public float sourceFireRat;
    protected float timer;
    [Header("散射子弹数")]
    public int shotGunBulletNum;

    private void Start()
    {
        sourceFireRat = FireRat;
    }
    public void CommGunFire()//连射子弹发射
    {
        if (player.targetEnemy != null)
        {
            timer += Time.deltaTime;
            if (timer > FireRat)
            {
                timer = 0;
                GameObject bullet = Instantiate(playerBullet, fireTrans.position, fireTrans.rotation * Quaternion.AngleAxis(Random.Range(-gunSight, gunSight), Vector3.forward));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * firePower, ForceMode2D.Impulse);
            }
        }
    }

    public void ShotGunFire()//散射子弹发射
    {
        List<GameObject> shotBullets = new List<GameObject>();
        if (player.targetEnemy != null)
        {
            timer += Time.deltaTime;
            float tempFireRat = FireRat * 4;
            if (timer > tempFireRat)
            {
                for (int i = 0; i < (shotGunBulletNum); i++)
                {
                    timer = 0;
                    float tempGunSight = gunSight * 2f;
                    GameObject bullet = Instantiate(playerBullet, fireTrans.position, fireTrans.rotation * Quaternion.AngleAxis(Random.Range(-tempGunSight, tempGunSight), Vector3.forward));
                    shotBullets.Add(bullet);
                }
                for (int i = 0; i < (shotGunBulletNum); i++)
                {
                    shotBullets[i].GetComponent<Rigidbody2D>().AddForce(shotBullets[i].transform.right * firePower, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void RingGunFire()//环形子弹发射
    {
        if (player.targetEnemy != null)
        {
            timer += Time.deltaTime;
            float tempFireRat = FireRat * 4;
            if (timer > tempFireRat)
            {
                Vector3 Direction = this.transform.up;
                Quaternion startQuaternion = Quaternion.AngleAxis(360 / shotGunBulletNum, Vector3.forward);

                for (int j = 0; j < shotGunBulletNum; j++)
                {
                    timer = 0;
                    GameObject bullet = Instantiate(playerBullet);
                    bullet.transform.position = transform.position;
                    bullet.transform.rotation = Quaternion.Euler(Direction);
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bullet.transform.rotation.x, bullet.transform.rotation.y, bullet.transform.position.z) * (firePower * 40), ForceMode2D.Impulse);
                    Direction = startQuaternion * Direction;
                }
            }
        }
    }
}
