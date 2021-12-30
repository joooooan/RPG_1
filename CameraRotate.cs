using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    private float _rotateSpeedX;
    private float _rotateSpeedY;
    private float _limitX;
    private float _eulerAngleX;
    private float _eulerAngleY;

    private void Awake()
    {
        _rotateSpeedX = 3;
        _rotateSpeedY = 5;
        _limitX = 80;
        _eulerAngleX = 0 ;
        _eulerAngleY = 0;
    }

    public void RatateTo(float mousex,float mousey)
    {
        _eulerAngleY += mousex * _rotateSpeedX;

        _eulerAngleX -= mousey * _rotateSpeedY;

        _eulerAngleX = Mathf.Clamp(_eulerAngleX, -_limitX, _limitX);

        this.transform.rotation = Quaternion.Euler(_eulerAngleX, _eulerAngleY, 0);
    }

    
}
