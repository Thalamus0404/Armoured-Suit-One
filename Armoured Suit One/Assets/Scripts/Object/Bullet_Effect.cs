using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Effect : MonoBehaviour
{
    public GameObject bulletEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            bulletEffect.SetActive(true);
        }
    }
}
