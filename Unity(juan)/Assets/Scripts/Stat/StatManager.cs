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
        PlayerPrefs.SetInt("Lv", 1);

        PlayerPrefs.SetInt("Exp", 0);
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

    public int GetPlayerStat(int Lv,string StatName)
    {
        
        for (int i = 0; i < _playerData.Count; i++)
        {
            if ((int)_playerData[i]["Lv"] == Lv)
            {
                //Debug.Log(_playerData[i][StatName] + "을 받아옴.(Player)");
                return (int)_playerData[i][StatName];
            }
        }

        Debug.Log("일치하는 플레이어의 능력치가 없습니다.");
        return 0;

    }

    public int GetMonsterStat(string Name, string StatName)
    {

        for(int j = 0; j < _monsterData.Count; j++)
        {
            if ((string)_monsterData[j]["Name"] == Name)
            {
                Debug.Log(_monsterData[j][StatName] + "을 받아옴.(Monster)");
                return (int)_monsterData[j][StatName];
            }
        }         

        Debug.Log("일치하는 몬스터가 없습니다.");
        return 0;
    }

    public void PlayerLevelUp()
    {
        int currLv = PlayerPrefs.GetInt("Lv");
        currLv += 1;
        PlayerPrefs.SetInt("Lv", currLv);

    }

    public void SetPlayerExp(int Exp)
    {
        int currExp = PlayerPrefs.GetInt("Exp"); //현재 경험치를 받아옴
        int currLv = PlayerPrefs.GetInt("Lv");//현재 레벨을 받아옴
        currExp += Exp;

        for (int i = 0; i < _playerData.Count; i++)
        {
            if ((int)_playerData[i]["Lv"] == currLv)
            {
                if (currExp >= (int)_playerData[i]["Exp"] )
                {
                    currExp -= (int)_playerData[i]["Exp"]; //현재 경험치 - 필요 경험치
                    PlayerLevelUp(); //레벨 업

                    break;
                }
            }
        }

        PlayerPrefs.SetInt("Exp", currExp);
    }


}
