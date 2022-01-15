using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor_Enegy_Circle : MonoBehaviour
{
    Image energyCircle;
    public int statX;
    public int maxStatX;

    void Start()
    {
        energyCircle = GetComponent<Image>();
    }

    void LateUpdate()
    {
        energyCircle.fillAmount = (float)statX / (float)maxStatX;
    }
}
