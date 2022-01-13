using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_DataBase : MonoBehaviour
{
    //public TextAsset jsonNpcStatText;
    //public TextAsset jsonNPCLevelText;
    //public TextAsset jsonNPCWeaponText;
    //public TextAsset jsonPlayerStatText;
    //public TextAsset jsonPlayerUpgradeText;
    

    
    //public List<NPC_Stat> npcStat = new List<NPC_Stat>();    
    //public List<NPC_Level> npcLevel = new List<NPC_Level>();   
    //public List<NPC_Weapon> npcWeapon = new List<NPC_Weapon>();   
    //public List<Player_Stat> playerStat = new List<Player_Stat>(); 
    //public List<Player_Upgrade> playerUpgrade = new List<Player_Upgrade>();    
    //public List<Player_Weapon> playerWeapon = new List<Player_Weapon>();

    //void Start()
    //{
    //    string npcStatData = jsonNpcStatText.text;
    //    var jsonNpcStat = JSON.Parse(npcStatData);
    //    for (int i = 0; i < jsonNpcStat.Count; i++)
    //    {
    //        NPC_Stat npc = new NPC_Stat();
    //        npc.index = int.Parse(jsonNpcStat[i]["Index"]);
    //        npc.name = jsonNpcStat[i]["Name"];
    //        npc.type = jsonNpcStat[i]["Type"];
    //        npc.hp = int.Parse(jsonNpcStat[i]["Hp"]);
    //        npc.shield = int.Parse(jsonNpcStat[i]["Shield"]);
    //        npc.armor = int.Parse(jsonNpcStat[i]["Armor"]);
    //        npc.speed = int.Parse(jsonNpcStat[i]["Speed"]);
    //        this.npcStat.Add(npc);
    //    }
    //    string npcLevelData = jsonNPCLevelText.text;
    //    var jsonNpcLevel = JSON.Parse(npcLevelData);
    //    for (int i = 0; i < jsonNpcLevel.Count; i++)
    //    {
    //        NPC_Level npc = new NPC_Level();
    //        npc.index = int.Parse(jsonNpcLevel[i]["Index"]);
    //        npc.levelName = jsonNpcLevel[i]["Name"];
    //        npc.hpPer = int.Parse(jsonNpcLevel[i]["HpPer"]);
    //        npc.shieldPer = int.Parse(jsonNpcLevel[i]["ShieldPer"]);
    //        npc.armorPer = int.Parse(jsonNpcLevel[i]["ArmorPer"]);
    //        npcLevel.Add(npc);
    //    }
        //string npcWeaponData = jsonNPCWeaponText.text;
        //var jsonNpcWeapon = JSON.Parse(npcWeaponData);
        //for (int i = 0; i < jsonNpcWeapon.Count; i++)
        //{
        //    NPC_Weapon npc = new NPC_Weapon();
        //    npc.index = int.Parse(jsonNpcWeapon[i]["Index"]);
        //    npc.objectName = jsonNpcWeapon[i]["Name"];
        //    npc.atk = int.Parse(jsonNpcWeapon[i]["ATK"]);
        //    npc.speed = int.Parse(jsonNpcWeapon[i]["Speed"]);
        //    npc.range = int.Parse(jsonNpcWeapon[i]["Range"]);
        //    npcWeapon.Add(npc);
        //}
        //string playerStatData = jsonPlayerStatText.text;
        //var jsonPlayerStat = JSON.Parse(playerStatData);
        //for (int i = 0; i < jsonPlayerStat.Count; i++)
        //{
        //    Player_Stat pc = new Player_Stat();
        //    pc.index = int.Parse(jsonPlayerStat[i]["Index"]);
        //    pc.objectName = jsonPlayerStat[i]["Name"];
        //    pc.hp = int.Parse(jsonPlayerStat[i]["Hp"]);
        //    pc.shield = int.Parse(jsonPlayerStat[i]["Shield"]);
        //    pc.armor = int.Parse(jsonPlayerStat[i]["Armor"]);
        //    pc.speed = float.Parse(jsonPlayerStat[i]["Speed"]);
        //    pc.booster = int.Parse(jsonPlayerStat[i]["Booster"]);
        //    pc.energy = int.Parse(jsonPlayerStat[i]["Energy"]);
        //    pc.trans = int.Parse(jsonPlayerStat[i]["Trans"]);
        //    playerStat.Add(pc);
        //}
        //string playerUpData = jsonPlayerUpgradeText.text;
        //var jsonPlayerUp = JSON.Parse(playerUpData);
        //for (int i = 0; i < jsonPlayerUp.Count; i++)
        //{
        //    Player_Upgrade pc = new Player_Upgrade();
        //    pc.index = int.Parse(jsonPlayerUp[i]["Index"]);
        //    pc.upgradeName = jsonPlayerUp[i]["Name"];
        //    pc.cost = int.Parse(jsonPlayerUp[i]["Cost"]);
        //    pc.hpUp = int.Parse(jsonPlayerUp[i]["HpUp"]);
        //    pc.shieldUp = int.Parse(jsonPlayerUp[i]["ShieldUp"]);
        //    pc.energyUp = int.Parse(jsonPlayerUp[i]["EnergyUp"]);
        //    pc.transUp = int.Parse(jsonPlayerUp[i]["TransUp"]);
        //    playerUpgrade.Add(pc);
        //}
        //string playerWeaponData = jsonPlayerWeaponText.text;
        //var jsonPlayerWeapon = JSON.Parse(playerWeaponData);
        //for (int i = 0; i < jsonPlayerWeapon.Count; i++)
        //{
        //    Player_Weapon weapon = new Player_Weapon();
        //    weapon.index = int.Parse(jsonPlayerWeapon[i]["Index"]);
        //    weapon.objectName = jsonPlayerWeapon[i]["Name"];
        //    weapon.atk = int.Parse(jsonPlayerWeapon[i]["ATK"]);
        //    weapon.speed = int.Parse(jsonPlayerWeapon[i]["Speed"]);
        //    weapon.range = int.Parse(jsonPlayerWeapon[i]["Range"]);
        //    weapon.energy = int.Parse(jsonPlayerWeapon[i]["Energy"]);
        //    weapon.trans = int.Parse(jsonPlayerWeapon[i]["Trans"]);
        //    weapon.charge = int.Parse(jsonPlayerWeapon[i]["Charge"]);
        //    playerWeapon.Add(weapon);
        //}
    //}
}
