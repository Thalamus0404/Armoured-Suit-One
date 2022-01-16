using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Mgr : MonoBehaviour
{
    public GameObject weapon;
    public GameObject bulletPrefab;
    public GameObject missalePrefab;

    public Transform firePosition;
    public Vector3 mouse100Z;

    public float bulletCoolTime = 1f;
    public float bulletCurTime;

    Bullet_Mgr bullet_Mgr;

    public float bulletSpeed;
    public int bulletDamage;
    public int energyCost;
    public int transCost;
    public int bulletCharge;

    public float missaleSpeed;
    public int missaleDamage;
    public int missaleCharge;
    public float missaleAimTime = 3f;
    public float missaleRange = 100f;

    public Player_Mgr player;

    public int energyRegen = 100;

    public AudioClip gunSound;
    public AudioClip missaleSound;
    public AudioSource audioSource;
    public AudioClip aimSound;

    public GameObject lockOnTarget;
    public GameObject aimTarget;
    public float aimTime;

    RaycastHit hit;    

    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        weapon = bulletPrefab;
        bulletSpeed = player.weapon1Speed;
        bulletDamage = player.weapon1ATK;
        energyCost = player.weapon1Energy;
        transCost = player.weapon1Trans;
        bulletCharge = player.weapon1Charge;
        missaleSpeed = player.weapon2Speed;
        missaleDamage = player.weapon2ATK;
        missaleCharge = player.weapon2Charge;
        //bulletPrefab1.tag = "Weapon 1";
        //bulletPrefab2.tag = "Weapon 2";        
        bulletCurTime = bulletCoolTime;
        missaleAimTime = aimSound.length;
    }
    
    void Update()
    {        
        if (bulletCurTime <= bulletCoolTime)
        {
            bulletCurTime += Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            BulletFire();
        }

        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);            
            if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
            {                
                TargetAimming();
            }
            else
            {
                aimTarget = null;
            }
        }

        if(Input.GetMouseButton(1) && player.weapon2Charge > 0)
        {
            if (aimTime <= missaleAimTime && aimTarget != null && aimTarget.tag == "Enemy")
            {
                aimTime += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (aimTime >= missaleAimTime && aimTarget.activeInHierarchy)
            {
                MissaleFire();
            }
            aimTime = 0;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            LockOn();
        }
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    WeaponSwap();
        //}

        EnergyRecharge();
    }

    public void LockOn()
    {
        if(lockOnTarget != null)
        {
            lockOnTarget = null;
        }        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.collider != null && hit.collider.gameObject.tag == "Enemy")
        {
            lockOnTarget = hit.collider.gameObject;
            lockOnTarget.GetComponent<Target>().enabled = true;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(lockOnTarget.transform.position);

        }
    }

    public void BulletFire()
    {
        if (bulletCurTime >= bulletCoolTime && energyCost != 0 && player.flightEnergy > energyCost)
        {
            MouseAim();
            Vector3 dir = mouse100Z - firePosition.position;
            dir.Normalize();
            bulletCurTime = 0;
            player.flightEnergy -= energyCost;
            audioSource.PlayOneShot(gunSound);
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, Quaternion.LookRotation(dir)) as GameObject;
            bullet.tag = "Player Bullet";
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
        }
        else if (bulletCurTime >= bulletCoolTime && energyCost == 0 && bulletCharge != 0)
        {
            MouseAim();
            Vector3 dir = mouse100Z - firePosition.position;
            dir.Normalize();
            bulletCharge--;
            bulletCurTime = 0;
            GameObject bullet = Instantiate(weapon, firePosition.transform.position, Quaternion.LookRotation(dir)) as GameObject;
            bullet.tag = "Player Bullet";
            bullet_Mgr = bullet.GetComponent<Bullet_Mgr>();
            bullet_Mgr.bulletSpeed = bulletSpeed;
            bullet_Mgr.bulletDamage = bulletDamage;
            Destroy(bullet, 1f);
        }
    }

    public void TargetAimming()
    {
        float distance = Vector3.Distance(hit.transform.position, transform.position);
        if (distance < missaleRange)
        {
            aimTarget = hit.collider.gameObject;
            audioSource.PlayOneShot(aimSound);
        }
    }

    public void MissaleFire()
    {
        player.weapon2Charge--;
        GameObject missale = Instantiate(missalePrefab, firePosition.transform.position, firePosition.transform.rotation) as GameObject;
        missale.tag = "Player Bullet";
        bullet_Mgr = missale.GetComponent<Bullet_Mgr>();
        bullet_Mgr.mainTarget = aimTarget;
        bullet_Mgr.bulletSpeed = missaleSpeed;
        bullet_Mgr.bulletDamage = missaleDamage;        
        audioSource.PlayOneShot(missaleSound);
        Destroy(missale, 10f);
    }
    //public void WeaponSwap()
    //{
    //    switch (weapon.tag)
    //    {
    //        case "Weapon 1":
    //            weapon = bulletPrefab2;
    //            player.weapon1Charge = charge;                
    //            bulletSpeed = player.weapon2Speed;
    //            bulletDamage = player.weapon2ATK;
    //            energyCost = player.weapon2Energy;
    //            transCost = player.weapon2Trans;
    //            charge = player.weapon2Charge;
    //            break;
    //        case "Weapon 2":
    //            weapon = bulletPrefab1;
    //            player.weapon2Charge = charge;
    //            bulletSpeed = player.weapon1Speed;
    //            bulletDamage = player.weapon1ATK;
    //            energyCost = player.weapon1Energy;
    //            transCost = player.weapon1Trans;
    //            charge = player.weapon1Charge;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    public void EnergyRecharge()
    {
        if(player.flightEnergy < player.maxflightEnergy)
        {
            player.flightEnergy += (int)(energyRegen * Time.deltaTime);
        }
        else
        {
            player.flightEnergy = player.maxflightEnergy;
        }
    }

    public void MouseAim()
    {
        var x = Input.mousePosition.x;
        var y = Input.mousePosition.y;
        float z = 100f;
        mouse100Z = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
        //Debug.Log(mouse100Z);
    }
}
