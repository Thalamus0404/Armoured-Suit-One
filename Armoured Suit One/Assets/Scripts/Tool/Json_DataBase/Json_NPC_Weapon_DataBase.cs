using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_NPC_Weapon_DataBase : MonoBehaviour
{
    public TextAsset jsonNPCWeaponText;
    public List<NPC_Weapon> npcWeapon = new List<NPC_Weapon>();
    
    void Start()
    {
        string npcWeaponData = jsonNPCWeaponText.text;
        var jsonNpcWeapon = JSON.Parse(npcWeaponData);
        for (int i = 0; i < jsonNpcWeapon.Count; i++)
        {
            NPC_Weapon npc = new NPC_Weapon();
            npc.index = int.Parse(jsonNpcWeapon[i]["Index"]);
            npc.objectName = jsonNpcWeapon[i]["Name"];
            npc.atk = int.Parse(jsonNpcWeapon[i]["ATK"]);
            npc.speed = int.Parse(jsonNpcWeapon[i]["Speed"]);
            npc.range = int.Parse(jsonNpcWeapon[i]["Range"]);
            npcWeapon.Add(npc);
        }
    }
}
