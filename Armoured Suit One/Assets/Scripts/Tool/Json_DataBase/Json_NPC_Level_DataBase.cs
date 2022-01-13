using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class Json_NPC_Level_DataBase : MonoBehaviour
{    
    public TextAsset jsonNPCLevelText;
    public List<NPC_Level> npcLevel = new List<NPC_Level>();    

    void Start()
    {
        string npcLevelData = jsonNPCLevelText.text;
        var jsonNpcLevel = JSON.Parse(npcLevelData);
        for (int i = 0; i < jsonNpcLevel.Count; i++)
        {
            NPC_Level npc = new NPC_Level();
            npc.index = int.Parse(jsonNpcLevel[i]["Index"]);
            npc.levelName = jsonNpcLevel[i]["Name"];
            npc.hpPer = int.Parse(jsonNpcLevel[i]["HpPer"]);
            npc.shieldPer = int.Parse(jsonNpcLevel[i]["ShieldPer"]);
            npc.armorPer = int.Parse(jsonNpcLevel[i]["ArmorPer"]);
            npcLevel.Add(npc);
        }
    }
}
