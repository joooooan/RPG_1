using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        _monsterState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        MonsterState();
    }

    void MonsterState()
    {
        switch(_monsterState)
        {
            case State.Idle:
                break;

            case State.Search:
                break;

            case State.Finding:
                break;

            case State.Move:
                break;

            case State.Attack:
                break;

            case State.Return:
                break;

            case State.Dead:
                break;
        }
    }
}
