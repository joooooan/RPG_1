using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Item : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("클릭 들어옴");
        Debug.Log(eventData.pointerEnter.tag);

        if(eventData.pointerEnter.tag == "Weapon_Product")
        {
            eventData.pointerEnter.gameObject.GetComponentInParent<Weapon_Shop>().Buy();
        }
        else if (eventData.pointerEnter.tag == "Soul_Product")
        {
            eventData.pointerEnter.gameObject.GetComponentInParent<Soul_Shop>().Buy();
        }
        else if(eventData.pointerEnter.tag == "Postion_Product")
        {
            eventData.pointerEnter.gameObject.GetComponentInParent<Other_Shop>().Buy();
        }

        
    }

}
