using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollsion : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            if(PlayerDataManager.Instance.Player._isEquip)
            {
                other.GetComponent<MonsterController>().TakeDamage(PlayerInventory.Instance.Equipment_WeaponName);
            }
            else
            {
                other.GetComponent<MonsterController>().TakeDamage("Hand");
            }
            
        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        this.gameObject.SetActive(false);

    }

}
