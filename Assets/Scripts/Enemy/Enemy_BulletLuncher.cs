using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletLuncher : MonoBehaviour
{
    public Enemy_Main enemy;
    public GameObject bullet;
    public float shootSpeed;
    [Header("索敌")]
    public Transform gunTrans;
    public GameObject targetPlayer;
    public Vector2 attackTarget;
    [Header("武器面板")]
    public GameObject enemyBullet;
    //public Transform fireTrans;
    public Transform fireTrans;
    public float gunSight;
    public float firePower;

    private void Start()
    {
        targetPlayer = Player_Main.instance.aimPointForEnemy;
    }
    private void Update()
    {
        GunController();
    }
    public void GunController()
    {
        if (targetPlayer != null)
        {
            attackTarget.x = targetPlayer.transform.position.x;
            attackTarget.y = targetPlayer.transform.position.y;
            Vector2 lookDir = attackTarget - (Vector2)gunTrans.position;
            lookDir = lookDir.normalized;
            gunTrans.right = lookDir;
        }
    }

    public void AN_EnemyGunFire()
    {
        if (targetPlayer != null)
        {
                GameObject bullet = Instantiate(enemyBullet, fireTrans.position, fireTrans.rotation * Quaternion.AngleAxis(Random.Range(-gunSight, gunSight), Vector3.forward));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * firePower, ForceMode2D.Impulse);
        }
    }
}
