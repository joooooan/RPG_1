using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class PlayerInventory : MonoBehaviour
{


    private static PlayerInventory instance = null;

    [SerializeField]
    public Inventory_Ui _ui;

    [SerializeField]
    GameObject _weaponSlot;
    [SerializeField]
    GameObject _soulSlot;
    [SerializeField]
    GameObject _materialSlot;

    int _weaponSlot_Size;
    int _soulSlot_Size;
    int _materialSlot_Size;

    Item_Weapon[] _weaponArray;
    Item_Soul[] _soulArray;
    Item_Material[] _materialArray;

    private string _weaponName = "";
    public string Equipment_WeaponName { get { return _weaponName; } set { _weaponName = value; } }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            _weaponSlot_Size = _weaponSlot.transform.childCount;
            _soulSlot_Size = _soulSlot.transform.childCount;
            _materialSlot_Size = _materialSlot.transform.childCount;

            _weaponArray = new Item_Weapon[_weaponSlot_Size];
            _soulArray = new Item_Soul[_soulSlot_Size];
            _materialArray = new Item_Material[_materialSlot_Size];

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PlayerInventory Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void AddInven(Item_Weapon weapon)
    {
       
        for (int i=0; i < _weaponSlot_Size; i++)
        {
           if(!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
           { 
                _weaponSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(weapon);
                _weaponArray[i] = weapon;

                break;
           }
           else
           {
                continue;
           }
        }
    }
    public void AddInven(Item_Material material)
    {
        for (int i = 0; i < _weaponSlot_Size; i++)
        {
            if (!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
            {
                _weaponSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(material);
                _materialArray[i] = material;

                break;
            }
            else
            {
                continue;
            }
        }
    }
    public void AddInven(Item_Soul soul)
    {

        for (int i = 0; i < _weaponSlot_Size; i++)
        {
            if (!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
            {
                _weaponSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(soul);
                _soulArray[i] = soul;

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void ReMoveWeapon(int index)
    {
        //_weaponSlot.transform.GetChild(index).GetComponent<Slot>().
    }

}



