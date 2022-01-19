using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soul_ToolTip : MonoBehaviour
{
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _stat;

    [SerializeField]
    Text _explain;


    public void SetText(Item_Soul _item)
    {
        _name.text = _item._name;

        _stat.text = "흡수 가능 능력치 : 1 ~ " + (_item._str + _item._def);

        _explain.text = _item._explain;
    }
}
