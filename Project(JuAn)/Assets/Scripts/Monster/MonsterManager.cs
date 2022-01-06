using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    //던전에 따른 출현 몬스터.
    [SerializeField]
    private GameObject _monsterPrefabs;

    //몬스터 스폰 시간
    [SerializeField]
    float _minSpawnTime = 1.0f;
    [SerializeField]
    float _maxSpawnTime = 5.0f;

    //던전에 존재할 수 있는 몬스터의 최대 수
    [SerializeField]
    float _monsterPoolSize = 10.0f;
    
    List<GameObject> _monsterPool;

    //스폰 지점
    [SerializeField]
    private GameObject _spawnPoints; 

    void Start()
    {
        int Type_size = _monsterPrefabs.transform.childCount;
        int spawn_size = _spawnPoints.transform.childCount;


        _monsterPool = new List<GameObject>();

        for(int i =0; i< _monsterPoolSize; i ++)
        {
            int type_number = Random.Range(0, Type_size);
            int spawn_number = Random.Range(0, spawn_size);

            GameObject monstersource = _monsterPrefabs.transform.GetChild(type_number).gameObject;
            GameObject monster = Instantiate(monstersource);

            _monsterPool.Add(monstersource);

            monster.transform.position = _spawnPoints.transform.GetChild(spawn_number).transform.position;
        }
    }
}
