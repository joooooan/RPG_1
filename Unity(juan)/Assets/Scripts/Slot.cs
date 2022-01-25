using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    enum Item_Type
    {
        Weapon,
        Material,
        Soul,
        Equip,
        Potion,
        Null

    }

    Item_Type _type = Item_Type.Null;

    public Sprite _emptyImage;

    Item_Weapon _weapon = null;
    Item_Material _material = null;
    Item_Soul _soul = null;
    Item_Potion _potion = null;

    private bool _isFull;
    public bool IsFull { get { return _isFull; } }
    // Start is called before the first frame update

    Vector3 pos;

    private void Start()
    {
        pos = this.transform.position;
    }

    public void AddItem(Item_Weapon item)
    {
        _isFull = true;
        _weapon = item;
        //Debug.Log("무기 이름 : " + _weapon._name);
        _type = Item_Type.Weapon;
        this.GetComponent<Image>().sprite = item._itemSprite;

    }
    public void AddItem(Item_Potion item)
    {
        _isFull = true;
        _potion = item;
        //Debug.Log("무기 이름 : " + _weapon._name);
        _type = Item_Type.Potion;
        this.GetComponent<Image>().sprite = item._itemSprite;

    }
    public void AddItem(GameObject item)
    {
        if(item.GetComponent<Item_Material>() != null)
        {
            _isFull = true;
            _material = item.GetComponent<Item_Material>();
            _type = Item_Type.Material;
            this.GetComponent<Image>().sprite = item.GetComponent<Item_Material>()._itemSprite;
        }
        else if (item.GetComponent<Item_Potion>() != null)
        {
            _isFull = true;
            _potion = item.GetComponent<Item_Potion>();
            _type = Item_Type.Potion;
            this.GetComponent<Image>().sprite = item.GetComponent<Item_Material>()._itemSprite;
        }

    }
    public void AddItem(Item_Soul item)
    {
        _isFull = true;
        _soul = item;
        _type = Item_Type.Soul;
        this.GetComponent<Image>().sprite = item._itemSprite;
    }

    public void Equip_Item(Item_Weapon item)
    {
        _weapon = item;                                         //빈 클래스에 받아온 무기 정보를 넣음.
        //Debug.Log("무기 이름 : " + _weapon._name);
        _type = Item_Type.Equip;                                //현재 상태를 장착으로 바꿈
        this.GetComponent<Image>().sprite = item._itemSprite;
        this.GetComponent<Image>().color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        ToolTip_UI_Manager.Instance.HideToolTip();

        switch (_type)
        {
            case Item_Type.Weapon:

                _type = Item_Type.Null;
                _isFull = false;
                PlayerInventory.Instance.EquipWeapon(_weapon);
                
                this.GetComponent<Image>().sprite = _emptyImage;

                _weapon = null;
                break;

            case Item_Type.Material:


                break;

            case Item_Type.Potion:

                this.GetComponent<Image>().sprite = _emptyImage;
                _type = Item_Type.Null;
                _isFull = false;
                

                PlayerDataManager.Instance.Player._CurrHp += _potion.HpCount;

                if(PlayerDataManager.Instance.Player._CurrHp > PlayerDataManager.Instance.Player._MaxHp)
                {
                    PlayerDataManager.Instance.Player._CurrHp = PlayerDataManager.Instance.Player._MaxHp;
                }
                _potion = null;
                break;

            case Item_Type.Soul:


                this.GetComponent<Image>().sprite = _emptyImage;
                break;

            case Item_Type.Equip:
                _type = Item_Type.Null;
                this.GetComponent<Image>().sprite = _emptyImage;

                PlayerInventory.Instance.ReleaseWeapon(_weapon);
                PlayerInventory.Instance.AddInven(_weapon);

                break;

            case Item_Type.Null:


                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (_type)
        {
            case Item_Type.Weapon:
                if (_weapon == null)
                {
                    Debug.Log("해당 슬롯에 무기에 대한 정보가 없습니다.");
                }


                ToolTip_UI_Manager.Instance.ShowToolTip(pos, _weapon);


                break;

            case Item_Type.Material:
                if (_material == null)
                {
                    Debug.Log("해당 슬롯에 재료에 대한 정보가 없습니다.");
                }
                ToolTip_UI_Manager.Instance.ShowToolTip(pos, _material);


                break;

            case Item_Type.Soul:
                if(_soul == null)
                {
                    Debug.Log("해당 슬롯에 소울에 대한 정보가 없습니다.");
                }

                ToolTip_UI_Manager.Instance.ShowToolTip(pos, _soul);
                break;

            case Item_Type.Equip:
                ToolTip_UI_Manager.Instance.ShowToolTip(pos, _weapon);


                break;

            case Item_Type.Null:


                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip_UI_Manager.Instance.HideToolTip();
    }
}
