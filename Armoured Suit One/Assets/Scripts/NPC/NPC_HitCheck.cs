using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HitCheck : MonoBehaviour
{
    public NPC_AI ai;
    public GameObject main;
    public Vector3 rndDirection;
    public NPC_Mgr npc;

    public float curTime;
    public float coolTime = 10f;

    public int shieldRegen = 1;

    public bool isDamaged = false;
    public bool isDead = false;

    void Start()
    {
        ai = main.GetComponent<NPC_AI>();
        npc = main.GetComponent<NPC_Mgr>();
        StartCoroutine("MakeRndDirection");
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
                curTime = 0;
                Destroy(other);
                isDamaged = true;
                if (main.gameObject.tag == "Enemy" && !isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    else
                    {
                        npc.shield = 0;
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Enemy Bullet":
                curTime = 0;
                Destroy(other);
                isDamaged = true;
                if (main.gameObject.tag == "Ally" && !isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    else
                    {
                        npc.shield = 0;
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Ally Bullet":
                curTime = 0;
                Destroy(other);
                isDamaged = true;
                if (main.gameObject.tag == "Enemy" && !isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    else
                    {
                        npc.shield = 0;
                        if (other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage >= npc.armor)
                        {
                            npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage - npc.armor;
                        }
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            default:
                break;
        }
        if (npc.hp <= 0 && !isDead)
        {
            npc.hp = 0;
            ai.npcState = NPC_AI.NPCSTATE.DESTROY;
        }
    }

    IEnumerator MakeRndDirection()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                rndDirection = main.transform.up;
                break;
            case 1:
                rndDirection = -main.transform.up;
                break;
            case 2:
                rndDirection = main.transform.right;
                break;
            case 3:
                rndDirection = -main.transform.right;
                break;
            default:
                break;
        }
        ai.evasionDirection = rndDirection;
        yield return new WaitForEndOfFrame();
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
            if (npc.shield < npc.maxShield)
            {
                npc.shield += shieldRegen;
            }
            else
            {
                npc.shield = npc.maxShield;
            }
        }
    }
}
