using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Interaction_Shop _Shop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Message_UI_Manager.Instance._interaction_Shop.SetActive(true);
            _Shop.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _Shop.gameObject.SetActive(false);
            Message_UI_Manager.Instance._interaction_Shop.SetActive(false);
            PopupUI_Manager.Instance.Close_PopupUi(PopupUI_Manager.Instance._shopPopup);
        }
    }
}
