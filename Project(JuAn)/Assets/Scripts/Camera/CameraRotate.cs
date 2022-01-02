using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    [SerializeField]
    float _rotSpeed = 05.5f;

    void Update()
    {
        RatateTo();
    }

    public void RatateTo()
    {

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) ;
        Vector3 camAngle = this.transform.rotation.eulerAngles;
        float angleX = camAngle.x - mouseDelta.y;

        if(angleX < 180)
        {
            angleX = Mathf.Clamp(angleX, -10f, 70f);
        }
        else
        {
            angleX = Mathf.Clamp(angleX, 355f, 361f);
        }

        this.transform.rotation = Quaternion.Euler(angleX, camAngle.y + mouseDelta.x, camAngle.z);

    }
}
