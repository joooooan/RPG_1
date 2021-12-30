using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float _playerSpeed = 5;

    private float _gravity;
    private Vector3 _moveDirection;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = this.GetComponentInChildren<CharacterController>();

        _gravity = -9.8f;
        _moveDirection = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        Gravity();

        _characterController.Move(_moveDirection* _playerSpeed* Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 movdDis = Camera.main.transform.rotation * direction;
        _moveDirection = new Vector3(movdDis.x, _moveDirection.y, movdDis.z);
        _moveDirection.Normalize();
    }

    public void Gravity()
    {
        if(_characterController.isGrounded == false)
        {
            _moveDirection.y += _gravity * Time.deltaTime;
        }
    }
}
