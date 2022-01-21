using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    protected int _hp;

    protected int _currhp;
    
    [SerializeField]
    protected int _mp;
    
    protected int _currmp;
    
    [SerializeField]
    protected int _atk;

    [SerializeField]
    protected int _def;

    [SerializeField]
    protected float _hitDelay = 0.3f;

    public int Hp { get { return _hp; } set { _hp = value; } }
    public int CurrHp { get { return _currhp; } set { _currhp = value; } }
    public int Mp { get { return _mp; } set { _mp = value; } }
    public int CurrMp { get { return _currmp; } set { _currmp = value; } }

    private void Awake()
    {
        _hp = 10;
        _currhp = _hp;
        _mp = 5;
        _currmp = _mp;
        _atk = 2;
        _def = 2;
    }
}
