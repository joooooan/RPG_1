using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Tab : MonoBehaviour
{
    

    [SerializeField]
    private GameObject _weaponTab;

    [SerializeField]
    private GameObject _soulTab;

    [SerializeField]
    private GameObject _materialTab;

    [SerializeField]
    private GameObject _statTab;

    void Awake()
    {
        disableTab();
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
        else if (_statTab.activeSelf == false)
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
        else if (_materialTab.activeSelf == false)
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
