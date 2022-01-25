using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _playerSpeed = 2.0f;

    [SerializeField]
    private float _rotateSpeed = 300f;

    [SerializeField]
    private float _attackDelay = 1.0f;

    [SerializeField]
    private PlayerAttackCollsion _attackCollsion;

    private float _currTime;

    private Movement _movement;
    private Animator _animator;

    private bool _isDead;

    private bool _isAttack;
    
    private bool _isDodge;

    private bool _isDelay;
    public bool HitDelay { get { return _isDelay; } }

    private Vector3 _dir;

    private void Awake()
    {

        _movement = this.GetComponentInChildren<Movement>();
        _animator = this.GetComponent<Animator>();      

        _currTime = Mathf.Infinity;
        _isAttack = false;
        _isDelay = false;

        _dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDataManager.Instance.Player._isDead == true) return;

        Moving();
        Dodge();
        Attacking();
        OpenInventory();
    }

    private void Moving()
    {
       
       
        float _h = Input.GetAxis("Horizontal");
        float _v = Input.GetAxis("Vertical");

        _dir = new Vector3(_h, 0, _v);

        

        _animator.SetFloat("Speed", _dir.magnitude);

        if (!(_h == 0 && _v == 0))
        {

            if (_attackCollsion._isAttack) _dir = Vector3.zero;

            _movement.MoveTo(_dir, _playerSpeed, _rotateSpeed);

        }
        else
        {

        }
       

    }

    private void Attacking()
    {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                _attackCollsion._isAttack = true;
                _animator.SetTrigger("isComboAttack");
            }
            else
            {

            }
        }      
    }

    private void Dodge()
    {
        if(!_isDodge)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _playerSpeed *= 2;
                _animator.SetTrigger("doDodge");
                _isDodge = true;
                _isDelay = true; //구르는 동안 데미지 안들어옴

            }
        }
        else
        {

        }
    }

    private void DodgeEnd()
    {

        Debug.Log("실행");
        _playerSpeed *= 0.5f;
        _isDodge = false;
        _isDelay = false;
    }

    public void Damage(string monsterName,string weaponName )
    {
        if(_isDead)
        {

        }

        if (!_isDelay)
        {
            _isDelay = true;
            StartCoroutine(Damaged(monsterName, weaponName));
        }
        else
        {
            Debug.Log("딜레이 중");
        }
    }

    IEnumerator Damaged(string monsterName, string weaponName)
    {
        _animator.SetTrigger("isDamaged");
        int damage = WeaponManager.Instance.GetWeaponData(weaponName, "Damage") + StatManager.Instance.GetMonsterStat(monsterName, "STR");
        damage -= PlayerDataManager.Instance.Player._Def;
        if (damage <= 0)
        {
            damage = 0;
        }
        PlayerDataManager.Instance.Player._CurrHp -= damage;

        if(PlayerDataManager.Instance.Player._CurrHp <=0 )
        {
            PlayerDataManager.Instance.Player._CurrHp = 0;

            PlayerDataManager.Instance.Player._isDead = true;
            _animator.SetTrigger("isDead");

            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            Debug.Log("Player가 공격 당함 (피해 : " + damage + ")");

            yield return new WaitForSeconds(PlayerDataManager.Instance.Player._HitDelay);

            _isDelay = false;
        }


        
    }

    private void TakeDamage() //공격판정 박스를 활성화 하는 함수
    {
        _attackCollsion.gameObject.SetActive(true);
        
        _animator.ResetTrigger("isComboAttack");
    }

    private void OpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

            Debug.Log("인벤토리 오픈");
            PopupUI_Manager.Instance.Open_PopupUi(PopupUI_Manager.Instance._inventoryPopup);
        }
    }

    public void onEquip(bool isEquip)
    {
        _animator.SetBool("isEquip", isEquip);
    }

}
