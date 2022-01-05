using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance = null;

    List<Dictionary<string, object>> _data = CSV_AssetReader.Read("Weapon/WeaponData");

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static WeaponManager Instance
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

    public int GetDamage(string name)
    {
        for(int i = 0; i <_data.Count; i++)
        {
            if ((string)_data[i]["Name"] == name)
            {
                return (int)_data[i]["Damage"];
            }
        }


        Debug.Log("엑셀 파일에 무기 이름이 없습니다.");
        return 0;
    }

}
