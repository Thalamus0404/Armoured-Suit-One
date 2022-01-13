using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HitCheck : MonoBehaviour
{
    public NPC_AI ai;
    public GameObject main;
    public Vector3 rndDirection;
    public NPC_Mgr npc;

    void Start()
    {
        ai = main.GetComponent<NPC_AI>();
        npc = main.GetComponent<NPC_Mgr>();
        StartCoroutine("MakeRndDirection");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !ai.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    else
                    {
                        npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Enemy Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Ally" && !ai.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    else
                    {
                        npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Ally Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !ai.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    if (npc.shield > 0)
                    {
                        npc.shield -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    else
                    {
                        npc.hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    }
                    ai.stateCurTime = 0;
                    ai.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            default:
                break;
        }
        if (npc.hp <= 0 && !ai.isDead)
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
}
