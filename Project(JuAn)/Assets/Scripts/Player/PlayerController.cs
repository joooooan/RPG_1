using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 2.0f;

    [SerializeField]
    private float _playerMaxSpeed = 4.0f;
    
    private Movement _movement;
    private Animator _animator;

    private bool _isMove;
    private Vector3 _movePoint;

    private GameObject _weapon;

    private void Awake()
    {
        _movement = this.GetComponentInChildren<Movement>();
        _animator = this.GetComponent<Animator>();
        _isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();

        if (_isMove)
        {
            float check = Mathf.Pow((_movePoint.x - this.transform.position.x) + (_movePoint.z - this.transform.position.z), 2);
            Debug.Log(check);

            if(check <= _movement.Nav_StoppingDistance)
            {
                _isMove = false;
                _animator.SetBool("isRun", _isMove);
            }

        }
    }

    private bool Moving()
    {
        RaycastHit hit; // Ray에 맞은 놈들 저장한다.
        if (Physics.Raycast(GetMouseRay(), out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(1) || Input.GetMouseButton(1))
            {
                _isMove = true;
                _movePoint = hit.point;
                _movement.MoveTo(_movePoint, _playerSpeed, _playerMaxSpeed);

                _animator.SetBool("isRun", _isMove);
            }

            return true;
        }

        return false;
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void Attacking()
    {
        //무기 검사
    }


}
