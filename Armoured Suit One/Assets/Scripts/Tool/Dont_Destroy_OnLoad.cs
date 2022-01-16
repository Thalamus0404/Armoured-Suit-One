using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_OnLoad : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);        
    }
}
