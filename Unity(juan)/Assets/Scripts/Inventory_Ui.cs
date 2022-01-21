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

    [SerializeField]
    private GameObject _weaponToolTip;

    [SerializeField]
    private GameObject _materialToolTip;

    [SerializeField]
    private GameObject _soulToolTip;



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

    public void ShowToolTip(Vector3 position,Item_Weapon _weapon)
    {
        _weaponToolTip.SetActive(true);

        Vector3 tipSize = new Vector3(_weaponToolTip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

        _weaponToolTip.transform.position = position + tipSize;
        _weaponToolTip.GetComponent<Weapon_ToolTip>().SetText(_weapon);
    }
    public void ShowToolTip(Vector3 position, Item_Material _material)
    {
        _materialToolTip.SetActive(true);
        Vector3 tipSize = new Vector3(_materialToolTip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);
        _materialToolTip.transform.position = position + tipSize;
        _materialToolTip.GetComponent<Material_ToolTip>().SetText(_material);
        
        
    }
    public void ShowToolTip(Vector3 position, Item_Soul _soul)
    {
        _soulToolTip.SetActive(true);

        Vector3 tipSize = new Vector3(_soulToolTip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

        _soulToolTip.transform.position = position + tipSize;
        _soulToolTip.GetComponent<Soul_ToolTip>().SetText(_soul);
    }


    public void HideToopTip()
    {
        _weaponToolTip.SetActive(false);
        _materialToolTip.SetActive(false);
        _soulToolTip.SetActive(false);
    }

}
