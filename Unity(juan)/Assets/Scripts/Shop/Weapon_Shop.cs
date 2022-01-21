using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon_Shop : MonoBehaviour
{
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _price;

    [SerializeField]
    Text _explain;

    [SerializeField]
    Item_Weapon[] _Items;

    [SerializeField]
    GameObject _product;

    private void OnEnable()
    {
        
    }
}
