using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class New_Start : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerDataManager.Instance.NewPlayerData();

        LoadManager.LoadScene("HomeScene");
    }

}
