using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{


    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Vector3 direction, float movespeed,float rotatespeed)
    {
        this.transform.position += direction * movespeed * Time.deltaTime;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotatespeed);
    }
}
