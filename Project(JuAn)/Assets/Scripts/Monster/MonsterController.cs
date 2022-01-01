using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MonsterController : MonoBehaviour
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

    Stat _stat;
    Ray _ray;

    private float _currTime;

    [SerializeField]
    private float _limitTime;

    // Start is called before the first frame update
    void Start()
    {
        _monsterState = State.Search;
        _stat = this.GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_stat == null) return; // 모든 몬스터는 Stat 클래스를 가지고 있어야 한다.

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
        if (_stat.Hp > _stat.CurrHp)
        {
            _currTime = 0;
            _monsterState = State.Search;
        }
    }

    private void Search()
    {
       //_currTime += Time.deltaTime;
       //
       //if (_currTime > _limitTime)
       //{
       //    _monsterState = State.Idle;
       //    Debug.Log("Search -> Idle ");
       //    _limitTime = 0;
       //}

        _ray = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(_ray.origin, _ray.direction * 50.0f, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit, 50.0f))
        {
            Debug.Log(hit.transform.tag);

            if (hit.transform.tag == "Player")
            {
                _monsterState = State.Finding;
            }
            
        }



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

}
