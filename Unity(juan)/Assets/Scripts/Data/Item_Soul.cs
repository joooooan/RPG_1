using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Soul")]
public class Item_Soul : ScriptableObject
{
    [SerializeField]
    public Sprite _itemSprite;
    [SerializeField]
    public GameObject _itemObject;

    public int count;
    public string _name;
    public int _str;
    public int _def;
    public string _explain;
    public int Price;
}
