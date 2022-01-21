using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCollsion : MonoBehaviour
{


    private void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string monsterName = this.GetComponentInParent<MonsterController>().gameObject.name;
            string weaponName = this.GetComponentInParent<MonsterController>().GetWeaponName();

            other.GetComponent<PlayerController>().Damage(monsterName, weaponName);
        }
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        this.gameObject.SetActive(false);
    }

}
