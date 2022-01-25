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
    Item_Potion[] _Items;

    [SerializeField]
    GameObject _product;

    int index;

    private void Awake()
    {
        index = Random.Range(0, _Items.Length);

        _name.text = _Items[index]._name;
        _price.text = ""+_Items[index].Price;
        _explain.text = _Items[index].Explain;

        _product.GetComponent<Image>().sprite = _Items[index]._itemSprite;
    }

    public void Buy()
    {
        if (_Items[index].Price > PlayerDataManager.Instance.Player._Gold)
        {
            Message_UI_Manager.Instance._enought_Gold.SetActive(true);
        }
        else
        {
            PlayerDataManager.Instance.Player._Gold -= _Items[index].Price;

            GameObject item = new GameObject();

            PlayerInventory.Instance.AddInven(_Items[index]);
            this.gameObject.SetActive(false);

        }


    }
}
