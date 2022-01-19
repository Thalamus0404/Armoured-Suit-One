using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrackingMoveCamera : MonoBehaviour
{    
    public void BoosterOnCamera()
    {
        transform.DOLocalMoveZ(-7f, 4f);
    }

    public void DefalutCamera()
    {
        transform.DOLocalMoveZ(-5f, 2f);        
    }

    public void DefalutRotationCamera()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), 3f);
    }

    public void WMoveCamera()
    {
        transform.DOLocalMoveZ(-5.5f, 4f);
    }

    public void SMoveCamera()
    {
        transform.DOLocalMoveZ(-3f, 4f);
    }

    public void TurnLeftCamera()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, -20f), 3f);
    }

    public void TurnRightCamera()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 20f), 3f);
    }
}
