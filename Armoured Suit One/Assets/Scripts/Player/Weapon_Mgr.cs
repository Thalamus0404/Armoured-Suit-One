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
    public int energyCost;
    public int transCost;
    public int charge;

    public Player_Mgr player;

    public int energyRegen = 1;

    void Start()
    {
        weapon = bulletPrefab1;
        bulletSpeed = player.weapon1Speed;
        bulletDamage = player.weapon1ATK;
        energyCost = player.weapon1Energy;
        transCost = player.weapon1Trans;
        charge = player.weapon1Charge;
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

        EnergyRecharge();
    }

    public void BulletFire()
    {
        if (weaponCurTime >= weaponCoolTime && energyCost != 0 && player.flightEnergy > energyCost)
        {
            weaponCurTime = 0;
            player.flightEnergy -= energyCost;
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, firePosition.transform.rotation) as GameObject;
            bullet.tag = "Player Bullet";
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
        }
        else if (weaponCurTime >= weaponCoolTime && energyCost == 0 && charge != 0)
        {
            charge--;
            weaponCurTime = 0;
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, firePosition.transform.rotation) as GameObject;
            bullet.tag = "Player Bullet";
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
        }
    }

    public void WeaponSwap()
    {
        switch (weapon.tag)
        {
            case "Weapon 1":
                weapon = bulletPrefab2;
                player.weapon1Charge = charge;                
                bulletSpeed = player.weapon2Speed;
                bulletDamage = player.weapon2ATK;
                energyCost = player.weapon2Energy;
                transCost = player.weapon2Trans;
                charge = player.weapon2Charge;
                break;
            case "Weapon 2":
                weapon = bulletPrefab1;
                player.weapon2Charge = charge;
                bulletSpeed = player.weapon1Speed;
                bulletDamage = player.weapon1ATK;
                energyCost = player.weapon1Energy;
                transCost = player.weapon1Trans;
                charge = player.weapon1Charge;
                break;
            default:
                break;
        }
    }

    public void EnergyRecharge()
    {
        if(player.flightEnergy < player.maxflightEnergy)
        {
            player.flightEnergy += energyRegen;
        }
        else
        {
            player.flightEnergy = player.maxflightEnergy;
        }
    }
}
