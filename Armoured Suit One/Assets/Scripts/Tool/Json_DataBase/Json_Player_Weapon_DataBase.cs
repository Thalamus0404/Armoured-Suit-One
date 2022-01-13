using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Json_Player_Weapon_DataBase : MonoBehaviour
{
    public TextAsset jsonPlayerWeaponText;
    public List<Player_Weapon> playerWeapon = new List<Player_Weapon>();

    void Start()
    {
        string playerWeaponData = jsonPlayerWeaponText.text;
        var jsonPlayerWeapon = JSON.Parse(playerWeaponData);
        for (int i = 0; i < jsonPlayerWeapon.Count; i++)
        {
            Player_Weapon weapon = new Player_Weapon();
            weapon.index = int.Parse(jsonPlayerWeapon[i]["Index"]);
            weapon.objectName = jsonPlayerWeapon[i]["Name"];
            weapon.atk = int.Parse(jsonPlayerWeapon[i]["ATK"]);
            weapon.speed = int.Parse(jsonPlayerWeapon[i]["Speed"]);
            weapon.range = int.Parse(jsonPlayerWeapon[i]["Range"]);
            weapon.energy = int.Parse(jsonPlayerWeapon[i]["Energy"]);
            weapon.trans = int.Parse(jsonPlayerWeapon[i]["Trans"]);
            weapon.charge = int.Parse(jsonPlayerWeapon[i]["Charge"]);
            playerWeapon.Add(weapon);
        }
    }
}
