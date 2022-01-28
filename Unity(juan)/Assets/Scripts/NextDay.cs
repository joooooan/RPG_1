using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDay : MonoBehaviour
{
    [SerializeField]
    GameObject Day_Collider;

    

    private void OnTriggerEnter(Collider other)
    {
        if (PlayerDataManager.Instance._isRest) return;

        if (other.tag == "Player")
        {
            Day_Collider.SetActive(true);
            Message_UI_Manager.Instance._SaveData.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            Day_Collider.SetActive(false);
            Message_UI_Manager.Instance._SaveData.SetActive(false);
        }
    }



}
