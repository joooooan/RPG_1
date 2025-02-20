﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

using KevinIglesias;

public class MonsterController : Stat
{
    private enum State
    {
        Idle,
        Search,
        GoToWayPoint,
        ArriveToWayPoint,
        Walking,
        Damaged,
        MissTarget,
        Attack,
        EndToAttacking,
        GoToAttack,
        Dead
    }


    private State _monsterState;

    [SerializeField]
    private Slider _hpbar;

    [SerializeField]
    private float _limitTime;

    [SerializeField]
    private float _monsterSpeed = 1;

    [SerializeField]
    private MonsterAttackCollsion _attackCollsion;

    private GameObject _way = null;

    [SerializeField]
    private Text _name;

    private int _index;

    private int _minEXP;
    private int _maxEXP;
    private int _exp;

    public bool _isDelay;
    private bool _isAttacking;
    private bool _isDead;

    private NavMeshAgent _agent;

    private WayPoint _waypoint;

    private float _currTime;
    private float _waitTime;

    private SearchBox _searchbox;

    private Animator _animator;

    MeleeWarriorLeftHandIK _weapon;

    private void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _searchbox = this.transform.GetComponentInChildren<SearchBox>();
        _agent = this.GetComponent<NavMeshAgent>();
        _weapon = this.GetComponent<MeleeWarriorLeftHandIK>();
    }

    private void OnEnable()
    {
        _monsterState = State.Idle;
        _currTime = 0;
        _waitTime = 0;
        _isDelay = false;
        _isDead = false;
        _isAttacking = false;

        if("MonsterSource(Clone)" != this.gameObject.name)
        {
            _hp = StatManager.Instance.GetMonsterStat(this.gameObject.name, "HP");
            _atk = StatManager.Instance.GetMonsterStat(this.gameObject.name, "STR");
            _def = StatManager.Instance.GetMonsterStat(this.gameObject.name, "DEF");
            _currhp = _hp;
            _index = 0;

            _minEXP = StatManager.Instance.GetMonsterStat(this.gameObject.name, "MinEXP");
            _maxEXP = StatManager.Instance.GetMonsterStat(this.gameObject.name, "MaxEXP");
            _exp = Random.Range(_minEXP, _maxEXP);

            _name.text = StatManager.Instance.GetMonsterKoreanName(this.gameObject.name);
            SetWayPoint();
        }

        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currhp <= 0) _monsterState = State.Dead; 

        MonsterState();
        HandleHp();

        if(_isAttacking)
        {
            
        }
            
    }

    void MonsterState()
    {
        switch (_monsterState)
        {
            case State.Idle:
                Idle();
                break;

            case State.Search:
                Search();
                break;

            case State.ArriveToWayPoint:
                ArriveToWayPoint();
                break;

            case State.GoToWayPoint:
                GoToWayPoint();
                break;

            case State.Damaged:
                Damaged();
                break;

            case State.Attack:
                Attack();
                break;

            case State.GoToAttack:
                GoToAttack();
                break;

            case State.EndToAttacking:
                EndToAttacking();
                break;

            case State.MissTarget:
                MissTarget();
                break;

            case State.Dead:
                Dead();
                break;
        }
    }

    private void Idle()
    {
        _waitTime += Time.deltaTime;

        SearchPlayer();

        if (_waitTime > _limitTime)
        {
            _agent.speed = 2f;
            _waitTime = 0;
            _agent.isStopped = false;
            Reset();
            _animator.SetBool("isWalk", true);
            _monsterState = State.GoToWayPoint;
        }
    }

    private void ArriveToWayPoint()
    {
        Reset();
        _monsterState = State.Idle;
    }

    private void Search()
    {
        //도착 했는지 확인하는 함수
        isArrive();

        SearchPlayer();
    }
    private void isArrive()
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 WayPoint = new Vector2(_waypoint.GetWayPoint(_index).x, _waypoint.GetWayPoint(_index).z);

        if (Vector2.Distance(currPoint, WayPoint) < 1)
        {
            _agent.isStopped = true;
            _index = _waypoint.GetNextIndex(_index);
            _monsterState = State.ArriveToWayPoint;
        }
    }

    private void GoToWayPoint()
    {
        MoveToWayPoint();
        SearchPlayer();
    }

    private void MoveToWayPoint()
    {
        _agent.destination = _waypoint.GetWayPoint(_index);
        _agent.speed = _monsterSpeed;
        _agent.isStopped = false;
        _monsterState = State.Search;
    }

    private void Dead()
    {

    }

    private void ObjectAdd()
    {
        MonsterManager monstermanager = GameObject.FindGameObjectWithTag("MonsterManager").GetComponent<MonsterManager>();
        monstermanager.MonsterDisable(this.gameObject);
    }

    private void Reset()
    {
        _animator.SetBool("isRun", false);
        _animator.SetBool("isWalk", false);
    }

    public void Attacked(string name)
    {
        if (_isDead) return;

        StartCoroutine(Damage(name));
        
    }

    IEnumerator Damage(string name)
    {

        int damage = WeaponManager.Instance.GetWeaponData(name, "Damage") + PlayerDataManager.Instance.Player._Str; 
        //무기 이름 , Player의 공격력 만큼 데미지 증가.

        damage -= _def; 
        //몬스터의 방어력 만큼 데미지 감소.

        
        if (damage <= 0) damage = 0;
        //데미지가 마이너스 일 경우 0으로 처리.

        GameObject Text = Instantiate(Message_UI_Manager.Instance._DamageText, this.transform.position + new Vector3(0, 2.0f, 0), Message_UI_Manager.Instance._DamageText.transform.rotation);
        Text.GetComponent<Damage_Borad>().damage = damage;
        //몬스터가 받은 데미지 텍스트 생성.

        if(_isDelay)
        {

        }
        else
        {
            _currhp -= damage;

            _isDelay = true;
            //데미지 적용.

            if (_currhp <= 0)
            {
                _animator.SetTrigger("isDeath");

                PlayerDataManager.Instance.PlusExp(_exp);
                PlayerDataManager.Instance.Player._Gold += StatManager.Instance.GetMonsterStat(this.gameObject.name, "Gold");
                //Player 보상 처리.

                Invoke("ObjectAdd", 5.0f);

                _isDead = true;
                //비활성화 시키고 몬스터를 List에 넣음.

                _monsterState = State.Dead;
                //현재 체력이 마이너스가 됐을 경우 상태를 죽음으로 변환.

                yield return new WaitForSeconds(5.0f);

            }
            else
            {
                Reset();
                _agent.isStopped = true;
                _animator.ResetTrigger("doAttack");
                _animator.SetTrigger("isHit");

                yield return new WaitForSeconds(_hitDelay);

                _monsterState = State.Damaged;
                _isDelay = false;
                _agent.isStopped = false;
            }
        }
        

        
    }

    private void Damaged()
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 targetPoint = new Vector2(_searchbox.GetPlayer().transform.position.x, _searchbox.GetPlayer().transform.position.z);

        if (Vector2.Distance(currPoint, targetPoint) < 2)
        {
            
            _agent.isStopped = true;
            _monsterState = State.Attack;
        }
        else
        {
            _agent.isStopped = false;
            _animator.SetBool("isRun", true);
            _monsterState = State.GoToAttack;
        }
    }

    

    private void SetWayPoint()
    {
        if(_way != null)
        {
            Destroy(_way.gameObject);
        }

        GameObject map = GameObject.FindGameObjectWithTag("Dungeon_Tile");

        _way = new GameObject("Way Point"); //부모 객체 생성
        _way.AddComponent<WayPoint>(); //WayPoint Script  추가
        _waypoint = _way.GetComponent<WayPoint>(); //추가한 Script에 연결.

        int count = 3;

        for (int i = 0; i < count; i++)
        {
            _waypoint.CreateWayPoint(_way); //길 생성
        }
    }

    private void SearchPlayer()
    {
        if (_searchbox.FindPlayer)
        {
            Debug.Log("Attack 상태로 변환");
            Reset();
            _agent.speed = 3f; //속도 변경
            _animator.SetBool("isRun", true); // 달리는 애니메이션 실행
            _monsterState = State.GoToAttack;
        }
        else
        {
           
        }
    }

    private void Attack()
    {
        if (_isDead) return;

        if (_isAttacking)
        {
            Vector3 dir = _searchbox.GetPlayer().transform.position - this.transform.position;
            dir.y = 0;
            dir.Normalize();

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), 10.0f * Time.deltaTime);
        }
        else
        {




            StartCoroutine(Attacking());
        }
    }

    private void GoToAttack()
    {
        if(_searchbox.FindPlayer)
        {
            _agent.destination = _searchbox.GetPlayer().transform.position; //이동 위치 설정

            TryAttact(_searchbox.GetPlayer().transform);
        }
        else
        {
            _waitTime += Time.deltaTime;

            if(_waitTime > 2.0f)
            {
                _waitTime = 0;
                Reset();
                _agent.isStopped = true;
                _monsterState = State.MissTarget;
            }

        }
    }

    private void TryAttact(Transform target)
    {
        Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 targetPoint = new Vector2(target.position.x, target.position.z);

        if (Vector2.Distance(currPoint, targetPoint) < 2)
        {
            _agent.isStopped = true;
            _monsterState = State.Attack;
        }
    }

    private void MissTarget()
    {
        _currTime += Time.deltaTime;

        if (_currTime > _limitTime)
        {

            _agent.destination = _waypoint.GetWayPoint(_index);
            _animator.SetBool("isWalk", true);
            _currTime = 0;
            _monsterState = State.GoToWayPoint;
        }

        if (_searchbox.FindPlayer)
        {
            Reset();
            _agent.isStopped = false;
            _animator.SetBool("isRun", true);
            _monsterState = State.GoToAttack;
        }

    }

    IEnumerator Attacking()
    {

        _isAttacking = true;
        _currTime = 0;
        Reset();
        _animator.SetTrigger("doAttack");
        float attackSpeed = WeaponManager.Instance.GetWeaponData(_weapon.GetGameObject().name, "AttackSpeed");

        yield return new WaitForSeconds(attackSpeed);

        _monsterState = State.EndToAttacking;
    }

    private void EndToAttacking()
    {
        _isAttacking = false;
        Reset();

        if (_searchbox.FindPlayer)
        {
            Vector2 currPoint = new Vector2(this.transform.position.x, this.transform.position.z);
            Vector2 targetPoint = new Vector2(_searchbox.GetPlayer().transform.position.x, _searchbox.GetPlayer().transform.position.z);

            if (Vector2.Distance(currPoint, targetPoint) < 2)
            {
                _agent.isStopped = true;
                _monsterState = State.Attack;
            }
            else
            {
                _agent.isStopped = false;
                _animator.SetBool("isRun", true);
                _monsterState = State.GoToAttack;
            }

        }
        else
        {
            _monsterState = State.Idle;         
        }
    }

    public string GetWeaponName()
    {
        return _weapon.GetGameObject().name;
    }

    public void OnAttackCollsion()
    {
        _attackCollsion.gameObject.SetActive(true);
    }

    private void HandleHp()
    {
        _hpbar.value = Mathf.Lerp(_hpbar.value, (float)_currhp / (float)_hp,Time.deltaTime*10);
    }

    

}
