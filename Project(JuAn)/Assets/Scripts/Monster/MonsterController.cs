using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MonsterController : Stat
{
    enum State
    {
        Idle,
        Search,
        Finding,
        Move,
        Attack,
        Return,
        Dead
    }

    State _monsterState;

    private float _currTime;

    [SerializeField]
    private float _hitDelay = 0.2f;

    private bool _isDelay;

    [SerializeField]
    private float _limitTime;



    // Start is called before the first frame update
    void Start()
    {
        _monsterState = State.Search;
        _isDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        MonsterState();
    }

    void MonsterState()
    {
        //if(_stat.CurrHp <= 0) _monsterState = State.Dead;

        switch (_monsterState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Search:
                Search();
                break;

            case State.Finding:
                Finding();
                break;

            case State.Move:
                Move();
                break;

            case State.Attack:
                Attack();
                break;

            case State.Return:
                Return();
                break;

            case State.Dead:
                Dead();
                break;
        }
    }

    private void Idle()
    {      
          _monsterState = State.Search;
        
    }

    private void Search()
    {

    }

    private void Finding()
    {
        //무기 상태에 따른 공격 판단.
    }

    private void Move()
    {
        //움직이는 중
    }

    private void Attack()
    {

    }

    private void Return()
    {

    }

    private void Dead()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand_L" || other.tag == "Hand_R")
        {
            if(!_isDelay)
            {
                StartCoroutine("Hit");
                
            }
            else
            {

            }
        }
    }

    IEnumerator Hit(string name)
    {
        _isDelay = true;
        int damage = WeaponManager.Instance.GetDamage(name);
        _currhp -= damage;

        Debug.Log("공격 당함 (피해 : " + damage + ")");

        yield return new WaitForSeconds(_hitDelay);
        _isDelay = false;
    }


}
