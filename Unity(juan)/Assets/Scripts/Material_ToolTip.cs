using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_ToolTip : MonoBehaviour
{
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _explain;

    public void SetText(Item_Material _item)
    {
        _name.text = _item._name;

        _explain.text = _item._explain;
    }
}
