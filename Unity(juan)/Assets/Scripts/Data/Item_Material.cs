using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/Material")]
public class Item_Material : ScriptableObject
{
    [SerializeField]
    public Sprite _itemSprite;
    [SerializeField]
    public GameObject _itemObject;

    public int id;
    public int count;
    public string _name;
    public string _explain;

}
