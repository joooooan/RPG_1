using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : Stat
{

    [SerializeField]
    private float _playerSpeed = 2.0f;
    [SerializeField]
    private float _rotateSpeed = 300f;
    
    private Movement _movement;
    private Animator _animator;
    private Attack_Player _attack;

    private GameObject _rightHand;
    private GameObject _leftHand;

    private bool _isMove;
    private bool _isAttack;
    private bool _isEquip;

    private float _comboTime;

    private void Awake()
    {
        _movement = this.GetComponentInChildren<Movement>();
        _animator = this.GetComponent<Animator>();
        _attack = this.GetComponent<Attack_Player>();
        _comboTime = 0.3f;
        _isEquip = false;
        _rightHand = GameObject.FindGameObjectWithTag("Hand_R");
        _leftHand = GameObject.FindGameObjectWithTag("Hand_L");
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Attacking();
    }

    private void Moving()
    {

        float _h = Input.GetAxis("Horizontal");      
        float _v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(_h, 0, _v);

        if (!(_h == 0 && _v == 0))
        {
            _animator.SetBool("isRun", true);
            _movement.MoveTo(dir, _playerSpeed, _rotateSpeed);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    private void Euqipment()
    {
        if (!_isEquip)
        {
            if(!_rightHand.activeSelf || !_leftHand.activeSelf)
            {
                _rightHand.SetActive(true);
                _leftHand.SetActive(true);
            }

        }
        else
        {
            if (_rightHand.activeSelf || _leftHand.activeSelf)
            {
                _rightHand.SetActive(false);
                _leftHand.SetActive(false);
            }
        }
    }

    private void Attacking()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !_animator.GetBool("isAttacking"))
        {
            _animator.SetBool("isAttacking", true);

            StartCoroutine("ComboAttack");

            //_attack.Attacking();
            //Debug.Log("공격");
        }
    }

    IEnumerator ComboAttack()
    {

        while(true)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            _comboTime -= Time.deltaTime;

            if (_comboTime <= 0) break;

            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                _animator.SetTrigger("isComboAttack");
                _comboTime = 0.3f;

                Debug.Log("공격");
            }
        }

        _animator.SetBool("isAttacking", false);
        _comboTime = 0.3f;
    }




}
