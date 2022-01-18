using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite _emptyImage;

    private bool _isFull;
    public bool IsFull { get { return _isFull; } }
    // Start is called before the first frame update

    public void AddItem(Item_Weapon item)
    {
        _isFull = true;

        this.GetComponent<Image>().sprite = item._itemSprite;
    }
    public void AddItem(Item_Material item)
    {
        _isFull = true;

        this.GetComponent<Image>().sprite = item._itemSprite;
    }
    public void AddItem(Item_Soul item)
    {
        _isFull = true;

        this.GetComponent<Image>().sprite = item._itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("들어옴");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("나감");
    }

    
}
