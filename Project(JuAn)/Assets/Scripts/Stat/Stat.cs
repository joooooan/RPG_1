using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    private int _hp;
    public int Hp { get { return _hp; } set { _hp = value; } }

    private int _currhp;
    public int CurrHp { get { return _currhp; } set { _currhp = value; } }

    [SerializeField]
    private int _mp;
    public int Mp { get { return _mp; } set { _mp = value; } }

    private int _currmp;
    public int CurrMp { get { return _currmp; } set { _currmp = value; } }

    [SerializeField]
    private int _atk;

    [SerializeField]
    private int _def;

    [SerializeField]
    private int _exp;


    // Start is called before the first frame update
    private void Awake()
    {
        _currhp = _hp;
        _currmp = _mp;
    }

}
