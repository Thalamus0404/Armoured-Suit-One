using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_Player_Stat_DataBase : MonoBehaviour
{
    public TextAsset jsonPlayerStatText;
    public List<Player_Stat> playerStat = new List<Player_Stat>();
    
    void Start()
    {
        string playerStatData = jsonPlayerStatText.text;
        var jsonPlayerStat = JSON.Parse(playerStatData);
        for (int i = 0; i < jsonPlayerStat.Count; i++)
        {
            Player_Stat pc = new Player_Stat();
            pc.index = int.Parse(jsonPlayerStat[i]["Index"]);
            pc.objectName = jsonPlayerStat[i]["Name"];
            pc.hp = int.Parse(jsonPlayerStat[i]["Hp"]);
            pc.shield = int.Parse(jsonPlayerStat[i]["Shield"]);
            pc.armor = int.Parse(jsonPlayerStat[i]["Armor"]);
            pc.speed = float.Parse(jsonPlayerStat[i]["Speed"]);
            pc.booster = int.Parse(jsonPlayerStat[i]["Booster"]);
            pc.energy = int.Parse(jsonPlayerStat[i]["Energy"]);
            pc.trans = int.Parse(jsonPlayerStat[i]["Trans"]);
            playerStat.Add(pc);
        }
    }
}
