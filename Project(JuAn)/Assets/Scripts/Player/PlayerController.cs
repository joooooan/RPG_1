using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 2.0f;
    
    private Movement _movement;
    private Animator _animator;
    private Attack_Player _attack;

    [SerializeField]
    private Weapon _weapon;

    private bool _isMove;
    private bool _isAttack;

    private float _comboTime;
    private int _currentCombo;

    RaycastHit _hit;

    private void Awake()
    {
        _movement = this.GetComponentInChildren<Movement>();
        _animator = this.GetComponent<Animator>();
        _attack = this.GetComponent<Attack_Player>();
        _isMove = false;
        _isAttack = false;
        _comboTime = 0.2f;
        _currentCombo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Attacking();
    }

    private void Moving()
    {
        float _h = Input.GetAxisRaw("Horizontal");
        float _v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(_h, 0, _v);

        _movement.MoveTo(dir,_playerSpeed);
       
    }

    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void Attacking()
    {
        
        if(_weapon == null)
        {
            Debug.Log("무기 정보가 없습니다."); 
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            _isAttack = true;
            _animator.SetBool("isAttacking", _isAttack);

            StartCoroutine("ComboAttack");

            //_attack.Attacking();

            //Debug.Log("공격");
        }
    }

    IEnumerator ComboAttack()
    {

        while(_isAttack)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            _comboTime -= Time.deltaTime;

            if (_comboTime <= 0) break;

            if (_currentCombo > _weapon.ComboMax) break;

            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                _animator.SetTrigger("isComboAttack");
                _currentCombo += 1;
                _comboTime = 0.2f;

                Debug.Log("공격");
            }
        }

        _isAttack = false;
        _currentCombo = 0;
        _animator.SetBool("isAttacking", _isAttack);
        _comboTime = 0.2f;
    }

}
