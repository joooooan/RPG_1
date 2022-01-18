
public class PlayerData
{
    public string _Name;
    public int _Lv;
    public int _NextExp;
    public int _CurrExp;
    public int _MaxHp;
    public int _CurrHp;
    public int _Str;
    public int _Def;
    public bool _isDead;
    public bool _isEquip;
    public float _HitDelay;

    public PlayerData()
    {
        _Name = "이름없음";
        _Lv = 1;
        _NextExp = 10;
        _CurrExp = 0;
        _MaxHp = 100;
        _CurrHp = _MaxHp;
        _Str = 2;
        _Def = 2;
        _HitDelay = 0.5f;
        _isDead = false;
        _isEquip = false;
    }
}
