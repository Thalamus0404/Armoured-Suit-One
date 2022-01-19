using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Maker : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject player;

    public GameObject dataBase;
    public Json_Player_Stat_DataBase stat_DataBase;
    public Json_Player_Weapon_DataBase weapon_DataBase;

    public int flightIndex;
    public int weapon1Index;
    public int weapon2Index;

    public string flightName;
    public int flightHp;
    public int flightShield;
    public int flightArmor;
    public float flightSpeed;
    public int flightBooster;
    public int flightEnergy;
    public int flightTrans;
    
    public string weapon1Name;
    public int weapon1ATK;
    public float weapon1Speed;
    public int weapon1Range;
    public int weapon1Energy;
    public int weapon1Trans;
    public int weapon1Charge;
    
    public string weapon2Name;
    public int weapon2ATK;
    public float weapon2Speed;
    public int weapon2Range;
    public int weapon2Energy;
    public int weapon2Trans;
    public int weapon2Charge;

    void Start()
    {
        dataBase = GameObject.Find("Json_DataBase");
        stat_DataBase = dataBase.GetComponent<Json_Player_Stat_DataBase>();
        weapon_DataBase = dataBase.GetComponent<Json_Player_Weapon_DataBase>();

        var playerStat = stat_DataBase.playerStat[flightIndex];
        flightName = playerStat.objectName;
        flightHp = playerStat.hp;
        flightShield = playerStat.shield;
        flightArmor = playerStat.armor;
        flightSpeed = playerStat.speed;
        flightBooster = playerStat.booster;
        flightEnergy = playerStat.energy;
        flightTrans = playerStat.trans;

        var playerWeapon1 = weapon_DataBase.playerWeapon[weapon1Index];
        weapon1Name = playerWeapon1.objectName;
        weapon1ATK = playerWeapon1.atk;
        weapon1Speed = playerWeapon1.speed;
        weapon1Range = playerWeapon1.range;
        weapon1Energy = playerWeapon1.energy;
        weapon1Trans = playerWeapon1.trans;
        weapon1Charge = playerWeapon1.charge;

        var playerWeapon2 = weapon_DataBase.playerWeapon[weapon2Index];
        weapon2Name = playerWeapon2.objectName;
        weapon2ATK = playerWeapon2.atk;
        weapon2Speed = playerWeapon2.speed;
        weapon2Range = playerWeapon2.range;
        weapon2Energy = playerWeapon2.energy;
        weapon2Trans = playerWeapon2.trans;
        weapon2Charge = playerWeapon2.charge;

        Player_Mgr player = playerPrefab.GetComponent<Player_Mgr>();
        player.flightIndex = flightIndex;
        player.flightName = flightName;
        player.flightHp = flightHp;
        player.flightShield = flightShield;
        player.flightArmor = flightArmor;
        player.flightSpeed = flightSpeed;
        player.flightBooster = flightBooster;
        player.flightEnergy = flightEnergy;
        player.flightTrans = flightTrans;

        player.weapon1Index = weapon1Index;
        player.weapon1Name = weapon1Name;
        player.weapon1ATK = weapon1ATK;
        player.weapon1Speed = weapon1Speed;
        player.weapon1Range = weapon1Range;
        player.weapon1Energy = weapon1Energy;
        player.weapon1Trans = weapon1Trans;
        player.weapon1Charge = weapon1Charge;

        player.weapon2Index = weapon2Index;
        player.weapon2Name = weapon2Name;
        player.weapon2ATK = weapon2ATK;
        player.weapon2Speed = weapon2Speed;
        player.weapon2Range = weapon2Range;
        player.weapon2Energy = weapon2Energy;
        player.weapon2Trans = weapon2Trans;
        player.weapon2Charge = weapon2Charge;

        //this.player = Instantiate(playerPrefab) as GameObject;
        //this.player.name = this.player.tag + flightName;
        //this.player.SetActive(false);
        //플레이어 소환 _ 현재 안씀
    }
}
