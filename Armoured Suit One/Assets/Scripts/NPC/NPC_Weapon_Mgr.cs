using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Weapon_Mgr : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject mainTarget;
    public GameObject weapon;
    public GameObject bulletPrefab1;
    public float fireCoolTime;
    public float fireCurTime;

    Bullet_Mgr bullet_Mgr;

    public float bulletSpeed;
    public int bulletDamage;

    public GameObject main;

    void Start()
    {
        weapon = bulletPrefab1;
    }

    void Update()
    {
        if (fireCurTime <= fireCoolTime)
        {
            fireCurTime += Time.deltaTime;
        }
    }

    public void NPCBulletFire()
    {
        if (fireCurTime >= fireCoolTime && mainTarget != null)
        {
            Vector3 dir = mainTarget.transform.position - firePosition.transform.position;
            dir.Normalize();
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, Quaternion.LookRotation(dir)) as GameObject;
            if (main.tag == "Ally")
            {
                bullet.tag = "Ally Bullet";
            }
            else if (main.tag == "Enemy")
            {
                bullet.tag = "Enemy Bullet";
            }
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
            fireCurTime = 0;
        }
    }
}
