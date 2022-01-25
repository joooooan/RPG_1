using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private static StatManager instance = null;

    public List<Dictionary<string, object>> _playerData;
    public List<Dictionary<string, object>> _monsterData;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            _playerData = CSV_AssetReader.Read("Stat/PlayerStatData");
            _monsterData = CSV_AssetReader.Read("Stat/MonsterStatData");



            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

    }

    public static StatManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public int GetPlayerStat(string statName)
    {

        for (int i = 0; i < _playerData.Count; i++)
        {
            if((int)_playerData[i]["Lv"] == PlayerDataManager.Instance.Player._Lv)
            {
                return (int)_playerData[i][statName];
            }

        }

        Debug.Log("Player 능력치를 찾을 수 없습니다.");
        return 0;

    }

    public int GetMonsterStat(string Name, string StatName)
    {

        for(int j = 0; j < _monsterData.Count; j++)
        {
            if ((string)_monsterData[j]["Name"] == Name)
            {
                //Debug.Log(_monsterData[j][StatName] + "을 받아옴.(Monster)");
                return (int)_monsterData[j][StatName];
            }
        }         

        Debug.Log("일치하는 몬스터가 없습니다.");
        return 0;
    }


}
