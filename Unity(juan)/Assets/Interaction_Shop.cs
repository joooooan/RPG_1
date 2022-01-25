using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Shop : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("키 누름");

            PopupUI_Manager.Instance.Open_PopupUi(PopupUI_Manager.Instance._shopPopup);
        }
    }
}
