using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Away_UI_Manager : MonoBehaviour
{
    private static Away_UI_Manager instance = null;

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

    public static Away_UI_Manager Instance
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
