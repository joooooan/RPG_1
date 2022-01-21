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

    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        DistanceControll();
    }

    private void Follow()
    {
        if (_player != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, _player.position, _lerpSpeed * Time.deltaTime);

            //this.transform.position = _player.position;

            Camera.main.transform.localPosition = new Vector3(0, _distance, -_distance);
        }
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
}
