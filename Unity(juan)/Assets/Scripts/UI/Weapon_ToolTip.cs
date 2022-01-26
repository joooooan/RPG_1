using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon_ToolTip : MonoBehaviour
{
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _atk;

    [SerializeField]
    Text _def;

    [SerializeField]
    Text _attackspeed;

    [SerializeField]
    Text _explain;

    public void SetText(Item_Weapon _item)
    {
        _name.text = _item._name;

        _atk.text = "공격력 : " + _item._str;

        _def.text = "방어력 : " + _item._def;

        _attackspeed.text = "공격 속도 : " + _item._attackdelay;

        _explain.text = _item._explain;
    }

}
