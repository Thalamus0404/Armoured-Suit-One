using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float weapon1Speed;
    public int weapon1Range;
    public int weapon1Energy;
    public int weapon1Trans;
    public int weapon1Charge;

    public int weapon2Index;
    public string weapon2Name;
    public int weapon2ATK;
    public float weapon2Speed;
    public int weapon2Range;
    public int weapon2Energy;
    public int weapon2Trans;
    public int weapon2Charge;

    public Slider_Mgr hpSlider;
    public Slider_Mgr shieldSlider;
    public Slider_Mgr transSlider;
    public Slider_Mgr energySlider;
    public Slider_Mgr boosterSlider;
    public Cursor_Enegy_Circle energyCircle;
    public Text bulletWeaponText;
    public Text bulletChargeText;
    public Text missaleWeaponText;
    public Text missaleChargeText;

    void Start()
    {
        maxflightHp = flightHp;
        maxflightShield = flightShield;
        maxflightBooster = flightBooster;
        maxflightEnergy = flightEnergy;
        maxflightTrans = flightTrans;
        flightTrans = 0;
        hpSlider = GameObject.Find("HpSlider").GetComponent<Slider_Mgr>();
        shieldSlider = GameObject.Find("ShieldSlider").GetComponent<Slider_Mgr>();
        transSlider = GameObject.Find("TransSlider").GetComponent<Slider_Mgr>();
        energySlider = GameObject.Find("EnergySlider").GetComponent<Slider_Mgr>();
        boosterSlider = GameObject.Find("BoosterSlider").GetComponent<Slider_Mgr>();
        energyCircle = GameObject.Find("EnergyCircle").GetComponent<Cursor_Enegy_Circle>();
        bulletWeaponText = GameObject.Find("BulletText").GetComponent<Text>();
        bulletChargeText = GameObject.Find("BulletChargeText").GetComponent<Text>();
        missaleWeaponText = GameObject.Find("MissaleText").GetComponent<Text>();
        missaleChargeText = GameObject.Find("MissaleChargeText").GetComponent<Text>();
        bulletWeaponText.text = "[ 01 ]" + weapon1Name;
        bulletChargeText.text = "";
        missaleWeaponText.text = "[ 01 ]" + weapon2Name;
        missaleChargeText.text = weapon2Charge.ToString();
    }

    void Update()
    {
        hpSlider.statX = flightHp;
        hpSlider.maxStatX = maxflightHp;
        shieldSlider.statX = flightShield;
        shieldSlider.maxStatX = maxflightShield;
        transSlider.statX = flightTrans;
        transSlider.maxStatX = maxflightTrans;
        energySlider.statX = flightEnergy;
        energySlider.maxStatX = maxflightEnergy;
        boosterSlider.statX = flightBooster;
        boosterSlider.maxStatX = maxflightBooster;
        energyCircle.statX = flightEnergy;
        energyCircle.maxStatX = maxflightEnergy;
        missaleChargeText.text = weapon2Charge.ToString();
    }
}
