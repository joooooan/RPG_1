
public class PlayerData
{
    public string _Name;
    public int _Lv;
    public int _NextExp;
    public int _CurrExp;
    public int _MaxHp;
    public int _CurrHp;
    public int _MaxMp;
    public int _CurrMp;
    public int _Str;
    public int _Def;
    public int _PlusHp;
    public int _PlusMp;
    public bool _isDead;
    public bool _isEquip;
    public float _HitDelay;
    public int _Gold;

    public PlayerData()
    {
        _Name = "이름없음";
        _Lv = 1;
        _NextExp = 10;
        _CurrExp = 0;
        _MaxHp = 100;
        _CurrHp = _MaxHp;
        _MaxMp = 0;
        _CurrMp = _MaxMp;
        _PlusHp = 0;
        _PlusMp = 0;
        _Str = 2;
        _Def = 2;
        _HitDelay = 0.5f;
        _isDead = false;
        _isEquip = false;
        _Gold = 0;
    }
}
