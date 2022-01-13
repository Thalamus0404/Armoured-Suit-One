using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_NPC_Stat_DataBase : MonoBehaviour
{
    public TextAsset jsonNpcStatText;
    public List<NPC_Stat> npcStat = new List<NPC_Stat>();

    void Start()
    {
        string npcStatData = jsonNpcStatText.text;
        var jsonNpcStat = JSON.Parse(npcStatData);
        for (int i = 0; i < jsonNpcStat.Count; i++)
        {
            NPC_Stat npc = new NPC_Stat();
            npc.index = int.Parse(jsonNpcStat[i]["Index"]);
            npc.name = jsonNpcStat[i]["Name"];
            npc.type = jsonNpcStat[i]["Type"];
            npc.hp = int.Parse(jsonNpcStat[i]["Hp"]);
            npc.shield = int.Parse(jsonNpcStat[i]["Shield"]);
            npc.armor = int.Parse(jsonNpcStat[i]["Armor"]);
            npc.speed = float.Parse(jsonNpcStat[i]["Speed"]);
            npcStat.Add(npc);
        }
    }
}
