using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour // 마우스 시점에 따라 오브젝트가 회전하게 끔 만듦.
{
    Vector3 mousePosition;

    public float sensitivity = 100;

    void Update()
    {
        mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float mouseRotationY = (mousePosition.x - 0.5f) * sensitivity * Time.deltaTime;
        float mouseRotationX = (mousePosition.y - 0.5f) * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.left * mouseRotationX);
        transform.Rotate(Vector3.up * mouseRotationY);
    }
}
