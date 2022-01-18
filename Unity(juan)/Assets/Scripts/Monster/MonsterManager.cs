using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterManager : MonoBehaviour
{

    //몬스터 정보
    [SerializeField]
    private GameObject _monsterSource;

    //몬스터가 들고있을 무기
    [SerializeField]
    private GameObject _weapon;

    //몬스터 종류
    private GameObject _monsters;

    //몬스터 스폰 시간
    [SerializeField]
    private float _minSpawnTime = 1.0f;
    [SerializeField]
    private float _maxSpawnTime = 5.0f;
    private float _cuurTime;
    private float _spawnTime;

    private int _spawnSize;

    //던전에 존재할 수 있는 몬스터의 최대 수
    [SerializeField]
    private float _monsterPoolSize = 10.0f;
    private List<GameObject> _monster_HpBarList;
    List<GameObject> _monsterPool;

    //스폰 지점
    [SerializeField]
    private GameObject _spawnPoints;

    [SerializeField]
    private GameObject _hpbar_Prefab = null;

    void Awake()
    {

        _monsters = _monsterSource.GetComponentInChildren<Monster_Type>().gameObject;

        int Type_size = _monsters.transform.childCount;
        
        int weapon_size = _weapon.transform.childCount;
        _cuurTime = 0;

        //Debug.Log(Type_size);

        _monsterPool = new List<GameObject>();


        for (int i = 0; i < _monsterPoolSize; i++)
        {
            int type_index = Random.Range(0, Type_size);
            int weapon_index = Random.Range(0, weapon_size);

            GameObject monster = Instantiate(_monsterSource);
            monster.GetComponentInChildren<Monster_Type>().transform.GetChild(type_index).gameObject.SetActive(true);
            monster.name = monster.GetComponentInChildren<Monster_Type>().transform.GetChild(type_index).gameObject.name;
            monster.tag = "Monster";

            GameObject weapon = Instantiate(_weapon.transform.GetChild(weapon_index).gameObject, monster.GetComponentInChildren<Monster_Hand>().transform);
            weapon.name = _weapon.transform.GetChild(weapon_index).gameObject.name;

            _monsterPool.Add(monster);
            monster.SetActive(false);
        }
    }

    void Start()
    {
        _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    void Update()
    {
        _cuurTime += Time.deltaTime;
        _spawnSize = _spawnPoints.transform.childCount;


        if (_cuurTime > _spawnTime)
        {
            if(_monsterPool.Count > 0)
            {
                int spawn_index = Random.Range(0, _spawnSize);

                GameObject monster = _monsterPool[0];
                monster.transform.position = _spawnPoints.transform.GetChild(spawn_index).transform.position;
                monster.SetActive(true);


                _monsterPool.Remove(monster);
            }

            _cuurTime = 0;

            _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);

        }

    }



    public void MonsterDisable(GameObject monster)
    {
        _monsterPool.Add(monster);
        monster.SetActive(false);
    }




}
