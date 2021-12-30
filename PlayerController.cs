using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.0f;

    private Vector3 _moveDirection;
    public Vector3 MoveDirection { set { _moveDirection = value; } }



    private CharacterController _characterController;
    private CameraRotate _cameraRotate;
    private Movement _movement;

    float _h;
    float _v;
    float _mx;
    float _my;

    private void Awake()
    {
        _cameraRotate = this.GetComponentInChildren<CameraRotate>();
        _characterController = this.GetComponentInChildren<CharacterController>();
        _movement = this.GetComponentInChildren<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInit();
    }

    private void MoveInit()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        _mx = Input.GetAxis("Mouse X");
        _my = Input.GetAxis("Mouse Y");

        _movement.MoveTo(new Vector3(_h, 0, _v));

        _cameraRotate.RatateTo(_mx, _my);
    }
}
