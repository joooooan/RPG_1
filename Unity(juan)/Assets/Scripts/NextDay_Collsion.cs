using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDay_Collsion : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerDataManager.Instance.SavePlayerDataToJson();

            PlayerDataManager.Instance.Player._CurrHp = PlayerDataManager.Instance.Player._MaxHp;
            PlayerDataManager.Instance.Player._CurrMp = PlayerDataManager.Instance.Player._MaxMp;

            LoadManager.LoadScene("HomeScene");

            PlayerDataManager.Instance._isRest = true;


        }
    }

}
