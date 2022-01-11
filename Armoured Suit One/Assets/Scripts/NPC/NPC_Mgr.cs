using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Mgr : MonoBehaviour
{
    public int npcHp = 100;
    public NPC_AI npc;
    public GameObject main;

    void Start()
    {
        npc = main.GetComponent<NPC_AI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !npc.isDead)
                {
                    npcHp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Enemy Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Ally" && !npc.isDead)
                {
                    npcHp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            case "Ally Bullet":
                Destroy(other);
                if (main.gameObject.tag == "Enemy" && !npc.isDead)
                {
                    npcHp -= other.gameObject.GetComponent<Bullet_Mgr>().bulletDamage;
                    npc.stateCurTime = 0;
                    npc.npcState = NPC_AI.NPCSTATE.EVASION;
                }
                break;
            default:
                break;
        }
        if (npcHp <= 0 && !npc.isDead)
        {
            npc.npcState = NPC_AI.NPCSTATE.DESTROY;
        }
    }

}
