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

    public int GetPlayerStat(string StatName)
    {
        
        for (int i = 0; i < _playerData.Count; i++)
        {
            return (int)_playerData[i][StatName];
        }

        Debug.Log("일치하는 플레이어의 능력치가 없습니다.");
        return 0;

    }

    public int GetMonsterStat(string Name, string StatName)
    {
        for (int i = 0; i < _monsterData.Count; i++)
        {
            if ((string)_monsterData[i][Name] == Name)
            {
                return (int)_monsterData[i][StatName];
            }
            else
            {
                Debug.Log("가지고 있는 능력치가 없습니다.");
                return 0;
            }
        }

        Debug.Log("일치하는 몬스터가 없습니다.");
        return 0;
    }

}
