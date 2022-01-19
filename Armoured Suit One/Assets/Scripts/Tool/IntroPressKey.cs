using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPressKey : MonoBehaviour
{
    Button button;
    public GameObject main;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            main.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
