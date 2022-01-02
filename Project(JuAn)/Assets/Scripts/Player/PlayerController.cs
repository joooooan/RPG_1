using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 5.0f;

    private CharacterController _characterController;
    private Movement _movement;

    float _h;
    float _v;

    private void Awake()
    {
        _characterController = this.GetComponentInChildren<CharacterController>();
        _movement = this.GetComponentInChildren<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(_h, 0, _v).normalized;

        _movement.MoveTo(moveVec);
    }
}
