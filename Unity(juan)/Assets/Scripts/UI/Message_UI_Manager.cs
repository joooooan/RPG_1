using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_UI_Manager : MonoBehaviour
{
    public GameObject _interaction_Shop;
    public GameObject _enought_Gold;
    public GameObject _SaveData;
    public GameObject _DamageText;

    private static Message_UI_Manager instance = null;

    private int _index;

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

    public static Message_UI_Manager Instance
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
