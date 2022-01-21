using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Posion")]
public class Item_Potion : ScriptableObject
{
    [SerializeField]
    public Sprite _itemSprite;
    [SerializeField]
    public GameObject _itemObject;

    public int count;
    public string _name;
    public int MpCount;
    public int HpCount;
    public int Price;
    public string Explain;
}
