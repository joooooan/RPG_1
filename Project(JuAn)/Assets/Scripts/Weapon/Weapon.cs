using UnityEngine;

//이름, 메뉴
[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/MakeNewWeaopn", order = 0)]
public class Weapon : ScriptableObject
{
    //무기 소스 이미지
    [SerializeField]
    GameObject _Source = null;

    //무기 애니메이션
    [SerializeField]
    AnimatorOverrideController _override = null;

    //무기 데미지
    [SerializeField]
    [Range(1.0f, 20.0f)]
    float _damage = 5.0f;
    public float Damage { get { return _damage; } }

    // 공격 범위
    [SerializeField]
    [Range(1.0f, 20.0f)]
    float _range = 2.0f;
    public float Range { get { return _range; } }

    public void Equip(Transform righthand, Transform lefthand, Animator animator)
    {
        //소스가 있으면 위치 할당
        if(_Source != null)
        {
            

        }

        //무기 전용 애니메이션도 할당
        if (_override)
        {
            animator.runtimeAnimatorController = _override;
        }

    }

}
