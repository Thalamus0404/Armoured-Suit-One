using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Mgr : MonoBehaviour
{
    public NPC_AI npc;
    public GameObject main;
    public Vector3 rndDirection;

    public NPC_Stat npcStat;
    public int index;
    public string objectName;
    public string objectType;
    public int hp;
    public int shield;
    public int armor;
    public float speed;

    void Start()
    {
        npc = main.GetComponent<NPC_AI>();
        StartCoroutine("MakeRndDirection");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !npc.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Enemy Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Ally" && !npc.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Ally Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !npc.isDead)
                {
                    StartCoroutine("MakeRndDirection");
                    hp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            default:
                break;
        }
        if (hp <= 0 && !npc.isDead)
        {
            npc.npcState = NPC_AI.NPCSTATE.DESTROY;
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
                rndDirection = - main.transform.up;
                break;
            case 2:
                rndDirection = main.transform.right;
                break;
            case 3:
                rndDirection = - main.transform.right;
                break;
            default:
                break;
        }
        npc.evasionDirection = rndDirection;
        yield return new WaitForEndOfFrame();
    }
}
