using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HitCheck : MonoBehaviour
{
    public GameObject main;
    public Player_Mgr player;

    public bool isDamaged = false;
    public bool isDead = false;

    public float curTime;
    public float coolTime = 10f;

    public int shieldRegen = 1;

    void Start()
    {
        player = main.GetComponent<Player_Mgr>();
    }

    void Update()
    {
        ShieldRecharge();
    }

    private void OnTriggerEnter(Collider other)
    {        
        switch (other.tag)
        {
            case "Player Bullet":
                break;
            case "Enemy Bullet":
                curTime = 0;
                Destroy(other);
                isDamaged = true;                
                if (player.flightShield > 0)
                {
                    if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= player.flightArmor)
                    {
                        player.flightShield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - player.flightArmor;
                    }
                }
                else
                {
                    if(other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= player.flightArmor)
                    {
                        player.flightHp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - player.flightArmor;
                    }
                }
                break;        
            case "Ally Bullet":
                Destroy(other);
                break;
            default:
                break;
        }
        if (player.flightHp <= 0 && !isDead)
        {
            player.flightHp = 0;
            isDead = true;
        }
    }

    public void ShieldRecharge()
    {
        if (curTime < coolTime)
        {
            curTime += Time.deltaTime;
        }
        else
        {
            isDamaged = false;
            if(player.flightShield < player.maxflightShield)
            {
                player.flightShield += shieldRegen;
            }
            else
            {
                player.flightShield = player.maxflightShield;
            }
        }
    }
}
