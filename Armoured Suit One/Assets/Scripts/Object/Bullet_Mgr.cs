using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mgr : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }
}
