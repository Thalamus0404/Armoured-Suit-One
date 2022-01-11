using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Mgr : MonoBehaviour
{
    public GameObject weapon;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    
    public Transform firePosition;

    public float weaponCoolTime = 1f;
    public float weaponCurTime;

    Bullet_Mgr bullet_Mgr;

    public float bulletSpeed;
    public int bulletDamage;

    void Start()
    {
        weapon = bulletPrefab1;
        bulletPrefab1.tag = "Weapon 1";
        bulletPrefab2.tag = "Weapon 2";        
        weaponCurTime = weaponCoolTime;
    }

    void Update()
    {
        if (weaponCurTime <= weaponCoolTime)
        {
            weaponCurTime += Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
                BulletFire();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
                WeaponSwap();
        }
    }

    public void BulletFire()
    {
        if (weaponCurTime >= weaponCoolTime)
        { 
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, firePosition.transform.rotation) as GameObject;
            bullet.tag = "Player Bullet";
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
            weaponCurTime = 0;
        }
    }

    public void WeaponSwap()
    {
        switch (weapon.tag)
        {
            case "Weapon1":
                weapon = bulletPrefab2;
                break;
            case "Weapon2":
                weapon = bulletPrefab1;
                break;
            default:
                break;
        }
    }
}
