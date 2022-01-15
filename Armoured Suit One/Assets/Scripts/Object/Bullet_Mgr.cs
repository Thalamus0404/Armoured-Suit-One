using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mgr : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public GameObject bulletEffect;

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Untagged")
        {
            GameObject bullet = Instantiate(bulletEffect, transform.position, transform.rotation);
            bullet.transform.localScale = 0.3f * bullet.transform.localScale;
            Destroy(gameObject);
        }
    }
}
