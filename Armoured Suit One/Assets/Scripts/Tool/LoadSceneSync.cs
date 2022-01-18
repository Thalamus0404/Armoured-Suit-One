using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneSync : MonoBehaviour
{
    public static string nextScene;
    public Text progressText;
    public string targetScene;

    private void Start()
    {
        StartCoroutine("LoadScene");
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Load Scene");
    }

    public IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation async = SceneManager.LoadSceneAsync(targetScene);
        async.allowSceneActivation = false;
        float timeX = 0;
        while(!async.isDone)
        {
            yield return null;
            timeX += Time.deltaTime;
            float progressPer = Mathf.Lerp(async.progress * 100f, 100f, timeX);
            progressText.text = "Now Loading... " + (int)progressPer + "%";
            if(async.progress >= 0.9f)
            {
                progressPer += Time.deltaTime;
                if (progressPer >= 100)
                {
                    timeX = 0;
                    progressPer = 100;
                    async.allowSceneActivation = true;
                }
            }
        }
    }
}
