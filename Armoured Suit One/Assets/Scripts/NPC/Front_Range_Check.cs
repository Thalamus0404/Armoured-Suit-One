using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front_Range_Check : MonoBehaviour
{
    public bool isRanged = false;
    public GameObject main;

    void Update()
    {
        //targets.RemoveAll(GameObject => GameObject != GameObject.activeInHierarchy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == main.gameObject.GetComponent<NPC_AI>().mainTarget)
        {
            if (main.tag == "Player")
            {
                if (other.gameObject.tag == "Enemy")
                {
                    isRanged = true;
                }
            }
            if (main.tag == "Enemy")
            {
                if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ally")
                {
                    isRanged = true;
                }
            }
            if (main.tag == "Ally")
            {
                if (other.gameObject.tag == "Enemy")
                {
                    isRanged = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == main.gameObject.GetComponent<NPC_AI>().mainTarget)
        {
            if (main.tag == "Enemy")
            {
                if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ally")
                {
                    isRanged = false;
                }
            }
            if (main.tag == "Ally")
            {
                if (other.gameObject.tag == "Enemy")
                {
                    isRanged = false;
                }
            }
        }
        else if (main.gameObject.GetComponent<NPC_AI>().mainTarget == null)
        {
            isRanged = false;
        }

    }
}
