using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float _playerSpeed = 2.0f;

    [SerializeField]
    public float _playerMaxSpeed = 4.0f;

    private CharacterController _characterController;
    private Movement _movement;
    

    private void Awake()
    {
        _characterController = this.GetComponentInChildren<CharacterController>();
        _movement = this.GetComponentInChildren<Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    private bool Moving()
    {
        RaycastHit hit; // Ray에 맞은 놈들 저장한다.
        if (Physics.Raycast(GetMouseRay(), out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
            {
                _movement.MoveTo(hit.point, _playerSpeed, _playerMaxSpeed);
            }

            return true;
        }

        return false;
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
