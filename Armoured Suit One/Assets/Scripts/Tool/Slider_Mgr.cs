using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Mgr : MonoBehaviour
{
    Slider slider;
    public int statX;
    public int maxStatX;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        if (maxStatX != 0)
        {
            slider.value = (float)statX / (float)maxStatX;
        }
    }
}
