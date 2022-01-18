using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    float _rotateSpeed = 1000;

    [SerializeField]
    private GameObject _playerModel;

    private Rigidbody _rigidbody;

    private Vector3 _dir;

    void Awake()
    {
        _dir = this.transform.forward;
        _rigidbody = this.transform.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixdUpdate()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        

        Quaternion newRotation = Quaternion.LookRotation(_dir);

        _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, newRotation, _rotateSpeed * Time.deltaTime);

        Debug.Log("캐릭터 방향 전환 중");
    }
}
