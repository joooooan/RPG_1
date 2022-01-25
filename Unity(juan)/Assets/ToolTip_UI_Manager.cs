using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip_UI_Manager : MonoBehaviour
{
    public GameObject _weaponTooltip;
    public GameObject _otherTooltip;
    public GameObject _soulTooltip;

    private static ToolTip_UI_Manager instance = null;

    Vector3 tipSize_Other;
    Vector3 tipSize_Weapon;
    Vector3 tipSize_Soul;


    private int _index;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            tipSize_Other = new Vector3(_otherTooltip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);
            tipSize_Weapon = new Vector3(_weaponTooltip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);
            tipSize_Soul = new Vector3(_soulTooltip.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static ToolTip_UI_Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void HideToolTip()
    {
        _weaponTooltip.SetActive(false);
        _otherTooltip.SetActive(false);
        _soulTooltip.SetActive(false);
    }

    public void ShowToolTip(Vector3 position, Item_Weapon _weapon)
    {
        _weaponTooltip.SetActive(true);
        _weaponTooltip.transform.position = position + tipSize_Weapon;
        _weaponTooltip.GetComponent<Weapon_ToolTip>().SetText(_weapon);
    }
    public void ShowToolTip(Vector3 position, Item_Material _other)
    {
        _otherTooltip.SetActive(true);

        _otherTooltip.transform.position = position + tipSize_Other;
        _otherTooltip.GetComponent<Material_ToolTip>().SetText(_other);

    }
    public void ShowToolTip(Vector3 position, Item_Soul _soul)
    {
        _soulTooltip.SetActive(true);
        _soulTooltip.transform.position = position + tipSize_Soul;
        _soulTooltip.GetComponent<Soul_ToolTip>().SetText(_soul);

    }

}
