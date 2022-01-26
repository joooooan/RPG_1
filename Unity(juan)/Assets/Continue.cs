using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Continue : MonoBehaviour, IPointerClickHandler
{
    public GameObject _text;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(PlayerDataManager.Instance.LoadPlayerDataToJson())
        {
            LoadManager.LoadScene("HomeScene");
        }
        else
        {
            _text.SetActive(true);
        }
    }
}
