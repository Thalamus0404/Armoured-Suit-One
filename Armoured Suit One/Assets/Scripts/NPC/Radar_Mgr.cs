using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar_Mgr : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject main;

    void Update()
    {
        targets.RemoveAll(GameObject => GameObject != GameObject.activeInHierarchy);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (main.tag == "Enemy")
                {
                    targets.Add(other.gameObject);
                }
                break;
            case "Enemy":
                if (main.tag == "Player" || main.tag == "Ally")
                {
                    targets.Add(other.gameObject);
                }
                break;
            case "Ally":
                if (main.tag == "Enemy")
                {
                    targets.Add(other.gameObject);
                }
                break;
            default:
                break;
        }
    }
}
