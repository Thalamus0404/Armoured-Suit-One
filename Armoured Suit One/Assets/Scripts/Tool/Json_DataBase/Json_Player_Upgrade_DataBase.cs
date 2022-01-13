using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_Player_Upgrade_DataBase : MonoBehaviour
{
    public TextAsset jsonPlayerUpgradeText;
    public List<Player_Upgrade> playerUpgrade = new List<Player_Upgrade>();

    void Start()
    {
        string playerUpData = jsonPlayerUpgradeText.text;
        var jsonPlayerUp = JSON.Parse(playerUpData);
        for (int i = 0; i < jsonPlayerUp.Count; i++)
        {
            Player_Upgrade pc = new Player_Upgrade();
            pc.index = int.Parse(jsonPlayerUp[i]["Index"]);
            pc.upgradeName = jsonPlayerUp[i]["Name"];
            pc.cost = int.Parse(jsonPlayerUp[i]["Cost"]);
            pc.hpUp = int.Parse(jsonPlayerUp[i]["HpUp"]);
            pc.shieldUp = int.Parse(jsonPlayerUp[i]["ShieldUp"]);
            pc.energyUp = int.Parse(jsonPlayerUp[i]["EnergyUp"]);
            pc.transUp = int.Parse(jsonPlayerUp[i]["TransUp"]);
            playerUpgrade.Add(pc);
        }
    }
}
