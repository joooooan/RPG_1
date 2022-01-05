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

    public void MoveTo(Vector3 direction, float speed)
    {
        this.transform.position += direction * speed * Time.deltaTime;
        this.transform.LookAt(this.transform.position, direction);
    }


}
