using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat_Ui : MonoBehaviour
{
    [SerializeField]
    Text Name;

    [SerializeField]
    Text STR;

    [SerializeField]
    Text DEF;

    [SerializeField]
    Text HP;

    [SerializeField]
    Text MP;

    [SerializeField]
    Text Level;

    [SerializeField]
    Text _currHp_Text;

    [SerializeField]
    Slider _currHp;

    [SerializeField]
    Text _currMp_Text;

    [SerializeField]
    Slider _currMp;

    private void OnEnable()
    {
        Name.text = "이름 : " + PlayerDataManager.Instance.Player._Name;

        Level.text = "레벨 : " + PlayerDataManager.Instance.Player._Lv;

        STR.text = "근력 : " + PlayerDataManager.Instance.Player._Str;

        DEF.text = "방어력 : " + PlayerDataManager.Instance.Player._Def;

        HP.text = "체력 : " + PlayerDataManager.Instance.Player._PlusHp;

        MP.text = "마력 : " + PlayerDataManager.Instance.Player._PlusMp;

        _currHp_Text.text = "Hp : (" + PlayerDataManager.Instance.Player._CurrHp + "/" + PlayerDataManager.Instance.Player._MaxHp + ")";
        _currMp_Text.text = "Mp : (" + PlayerDataManager.Instance.Player._CurrMp + "/" + PlayerDataManager.Instance.Player._MaxMp + ")";

    }


}
