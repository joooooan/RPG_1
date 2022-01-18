using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Ui : MonoBehaviour
{
    

    [SerializeField]
    private GameObject _weaponTab;

    [SerializeField]
    private GameObject _soulTab;

    [SerializeField]
    private GameObject _materialTab;

    [SerializeField]
    private GameObject _statTab;

    [SerializeField]
    private GameObject _inventory;

   

    void Awake()
    {
        disableTab();
        _inventory.SetActive(false);
    }

    public void OnInventory()
    {
        if(_inventory.activeSelf == false)
        {
            _inventory.SetActive(true);
        }
        else
        {
            disableTab();
            _inventory.SetActive(false);
        }
    }

    public void OnWeaponTab()
    {

        if (_weaponTab.activeSelf == true)
        {
            disableTab();
            _weaponTab.SetActive(false);
        }
        else if(_weaponTab.activeSelf == false)
        {
            disableTab();

            _weaponTab.SetActive(true);
        }

    }

    public void OnSoulTab()
    {
        if (_soulTab.activeSelf == true)
        {
            disableTab();
            _soulTab.SetActive(false);
        }
        else if(_soulTab.activeSelf == false)
        {
            disableTab();
            _soulTab.SetActive(true);
        }
    }

    public void OnStatTab()
    {
        if (_statTab.activeSelf == true)
        {
            disableTab();
            _statTab.SetActive(false);
        }
        else if (_soulTab.activeSelf == false)
        {
            disableTab();
            _statTab.SetActive(true);
        }
    }

    public void OnMaterialTab()
    {
        if (_materialTab.activeSelf == true)
        {
            disableTab();
            _materialTab.SetActive(false);
        }
        else if (_soulTab.activeSelf == false)
        {
            disableTab();
            _materialTab.SetActive(true);

        }
    }

    private void disableTab()
    {
        _weaponTab.SetActive(false);
        _statTab.SetActive(false);
        _materialTab.SetActive(false);
        _soulTab.SetActive(false);
    }


}
