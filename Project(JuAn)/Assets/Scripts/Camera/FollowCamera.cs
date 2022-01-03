using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    [Range(1f,10f)]
    private float _distance = 7f;

    [SerializeField]
    [Range(1f, 5.0f)]
    float _lerpSpeed = 5.0f;

    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
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
}
