using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Weapon")]
public class Item_Weapon : ScriptableObject
{
    [SerializeField]
    public Sprite _itemSprite;
    [SerializeField]
    public GameObject _itemObject;

    public int id;
    public string _name;
    public int _str;
    public int _def;
    public string _explain;
    public float _attackdelay;
}
