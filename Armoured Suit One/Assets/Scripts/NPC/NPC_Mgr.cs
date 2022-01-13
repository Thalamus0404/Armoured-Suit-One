using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Mgr : MonoBehaviour
{    
    public int index;
    public string objectName;
    public string objectType;
    public int hp;
    public int shield;
    public int armor;
    public float speed;

    public int weapon1Index;
    public string weapon1Name;
    public int weapon1ATK;
    public float weapon1Speed;
    public int weapon1Range;

    public int weapon2Index;
    public string weapon2Name;
    public int weapon2ATK;
    public float weapon2Speed;
    public int weapon2Range;

    public int maxHp;
    public int maxShield;


    void Start()
    {
        maxHp = hp;
        maxShield = shield;
    }
}
