using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Other_Shop : MonoBehaviour
{
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _price;

    [SerializeField]
    Text _explain;

    [SerializeField]
    Item_Posion[] _Items;

    [SerializeField]
    GameObject _product;

    private void OnEnable()
    {
        int index = Random.Range(0, _Items.Length);

        _name.text = _Items[index]._name;
        _price.text = ""+_Items[index].Price;
        _explain.text = _Items[index].Explain;


    }
}
