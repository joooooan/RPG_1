using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;



            DontDestroyOnLoad(this.gameObject); //이 GameObject를 싱글톤화.

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PlayerManager Instance
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
}
