using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Example_Json : MonoBehaviour
{
    public TextAsset exampleText;

    void Start()
    {
        string exampleJson = exampleText.text;

        var jsonData = JSON.Parse(exampleJson);
        Debug.Log(jsonData);
        Debug.Log(jsonData[1]["Name"]);
    }
}
