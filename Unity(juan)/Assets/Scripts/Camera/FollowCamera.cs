using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField]
    [Range(1f,10f)]
    private float _distance = 7f;

    [SerializeField]
    [Range(1f, 5.0f)]
    float _lerpSpeed = 5.0f;

    [SerializeField]
    float _scrollSpeed = 3.5f;

    float dis;

    RaycastHit _hit;

    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        dis = Vector2.Distance(Camera.main.transform.position, _player.position);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 13, Color.red);

        Follow();
        DistanceControll();
        //CamCollsion();
    }

    private void Follow()
    {

        this.transform.position = Vector3.Lerp(this.transform.position, _player.position, _lerpSpeed * Time.deltaTime);
        Camera.main.transform.localPosition = new Vector3(0, _distance, -_distance);

    }

    private void DistanceControll()
    {
       float value = Input.GetAxis("Mouse ScrollWheel");

       if(value > 0)
       {
           _distance -= value * _scrollSpeed;
       }
       else if (value <0)
       {
           _distance -= value * _scrollSpeed;
       }
       _distance = Mathf.Clamp(_distance, 3.5f, 10f);
    }
    
    private void CamCollsion()
    {





        

    }

}
