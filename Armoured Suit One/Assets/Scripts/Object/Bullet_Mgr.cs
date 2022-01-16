using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Mgr : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletSpeedX;
    public float missaleRotSpeed = 5f;
    public int bulletDamage;
    public GameObject bulletEffect;

    public GameObject mainTarget;
    public Vector3 moveDirection;

    private void Start()
    {
        moveDirection = Vector3.forward;
    }

    void Update()
    {
        transform.Translate(moveDirection * bulletSpeed * Time.deltaTime);
        if (mainTarget != null)
        {
            if (bulletSpeedX <= bulletSpeed)
            {
                bulletSpeedX += 0.002f * bulletSpeed;
            }
            else
            {
                bulletSpeedX = bulletSpeed;                
            }
            if (bulletSpeedX >= 0.2f * bulletSpeed)
            {
                Vector3 dir = mainTarget.transform.position - transform.position;
                Debug.DrawLine(mainTarget.transform.position, transform.position, Color.red);
                dir.Normalize();
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), missaleRotSpeed * Time.deltaTime);
            }
        }
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
