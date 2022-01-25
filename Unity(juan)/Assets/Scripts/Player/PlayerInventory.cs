using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using System;

public class PlayerInventory : MonoBehaviour
{
    private static PlayerInventory instance = null;

    [SerializeField]
    public GameObject _weapon;

    public PlayerController _player = null;

    [SerializeField]
    Text _gold;
    [SerializeField]
    public Text _level;

    [SerializeField]
    GameObject _weaponSlot;
    [SerializeField]
    GameObject _soulSlot;
    [SerializeField]
    GameObject _materialSlot;
    [SerializeField]
    GameObject _equipSlot;

    int _sizeTab;

    private string _weaponName = "";
    public string Equipment_WeaponName { get { return _weaponName; } set { _weaponName = value; } }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            _sizeTab = 16;
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

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

    private void Update()
    {
        Gold_Update();
    }

    public void AddInven(Item_Weapon weapon)
    {
       
        for (int i=0; i < _sizeTab; i++)
        {
           if(!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
           { 
                _weaponSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(weapon);

                break;
           }
           else
           {
                continue;
           }
        }
    }
    public void AddInven(Item_Potion material)
    {
        for (int i = 0; i < _sizeTab; i++)
        {
            if (!_materialSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
            {
                _materialSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(material);

                break;
            }
            else
            {
                continue;
            }
        }
    }
    public void AddInven(GameObject material)
    {
        for (int i = 0; i < _sizeTab; i++)
        {
            if (!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
            {
                _materialSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(material);

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

        for (int i = 0; i < _sizeTab; i++)
        {
            if (!_weaponSlot.transform.GetChild(i).GetComponent<Slot>().IsFull)
            {
                _soulSlot.transform.GetChild(i).GetComponent<Slot>().AddItem(soul);

                break;
            }
            else
            {
                continue;
            }
        }
    }


    //장비 장착
    public void EquipWeapon(Item_Weapon weapon)
    {
        //Debug.Log(PlayerDataManager.Instance.Player._isEquip);

        if(PlayerDataManager.Instance.Player._isEquip)
        {
            if(_weapon.transform.childCount > 0) //손에 있는 오브젝트를 삭제. 및 인벤토리에 추가
            {
                Destroy(_weapon.transform.GetChild(0).gameObject);
            }

            //현재 장착시킬려고 하는 무기를 오브젝트화 시키고 위치를 잡아줌.
            GameObject _currWeapon = Instantiate(weapon._itemObject, _weapon.transform);
            _currWeapon.name = weapon.name;
            _weaponName = weapon.name;

            //장비 슬롯에 무기 추가.
            _equipSlot.GetComponent<Slot>().Equip_Item(weapon);

            _player.onEquip(true);

        }
        else
        {
            GameObject _currWeapon = Instantiate(weapon._itemObject, _weapon.transform);
            _currWeapon.name = weapon.name;
            _weaponName = weapon.name;

            _player.onEquip(true);

            //장비 슬롯에 무기 추가.
            _equipSlot.GetComponent<Slot>().Equip_Item(weapon);

            PlayerDataManager.Instance.Player._isEquip = true;
        }
    }

    //장비 장착 해제
    public void ReleaseWeapon(Item_Weapon weapon)
    {

        //Debug.Log("해제");

        if (_weapon.transform.childCount > 0) //손에 있는 오브젝트를 삭제. 및 인벤토리에 추가
        {
            Destroy(_weapon.transform.GetChild(0).gameObject);
        }
        _player.onEquip(false);

    }

    //소지금 갱신
    public void Gold_Update()
    {
        _gold.text = ""+PlayerDataManager.Instance.Player._Gold;
    }

}



