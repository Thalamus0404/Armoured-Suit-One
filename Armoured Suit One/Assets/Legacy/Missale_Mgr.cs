using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missale_Mgr : MonoBehaviour
{
    public GameObject mainTarget;
    public float missaleSpeed;
    public float missaleSpeedX;
    public int missaleDamage;
    public float rotSpeed = 1f;

    void Update()
    {
        if (missaleSpeedX <= missaleSpeed)
        {
            missaleSpeedX += 0.002f * missaleSpeed;
        }
        else
        {
            missaleSpeedX = missaleSpeed;
        }
        transform.Translate(Vector3.forward * missaleSpeedX * Time.deltaTime);
        Vector3 dir = mainTarget.transform.position - transform.position;
        Debug.DrawLine(mainTarget.transform.position, transform.position, Color.red);
        dir.Normalize();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
    }
}
