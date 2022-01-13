using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mgr : MonoBehaviour
{
    public int flightIndex;
    public string flightName;
    public int flightHp;
    public int flightShield;
    public int flightArmor;
    public float flightSpeed;
    public int flightBooster;
    public int flightEnergy;
    public int flightTrans;

    public int maxflightHp;
    public int maxflightShield;
    public int maxflightBooster;
    public int maxflightEnergy;
    public int maxflightTrans;

    public int weapon1Index;
    public string weapon1Name;
    public int weapon1ATK;
    public int weapon1Speed;
    public int weapon1Range;
    public int weapon1Energy;
    public int weapon1Trans;
    public int weapon1Charge;

    public int weapon2Index;
    public string weapon2Name;
    public int weapon2ATK;
    public int weapon2Speed;
    public int weapon2Range;
    public int weapon2Energy;
    public int weapon2Trans;
    public int weapon2Charge;

    void Start()
    {
        maxflightHp = flightHp;
        maxflightShield = flightShield;
        maxflightBooster = flightBooster;
        maxflightEnergy = flightEnergy;
        maxflightTrans = flightTrans;
    }
}
