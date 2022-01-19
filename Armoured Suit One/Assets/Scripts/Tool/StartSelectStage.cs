using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSelectStage : MonoBehaviour
{
    public void StartStage(string sceneName)
    {
        LoadSceneSync.LoadScene(sceneName);
    }
}
