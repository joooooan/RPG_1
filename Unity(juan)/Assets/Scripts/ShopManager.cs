using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enterShop;

    [SerializeField]
    GameObject _shopUi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _enterShop.SetActive(true);
        }
    }

    private void Update()
    {
        if(_enterShop.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(_shopUi.activeSelf == true)
                {
                    _shopUi.SetActive(false);
                }
                else
                {
                    _shopUi.SetActive(true);
                }
                
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _shopUi.SetActive(false);
            _enterShop.SetActive(false);
        }
    }
}
