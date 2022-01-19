using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    Item_Weapon _weapon;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInventory.Instance.EquipWeapon(_weapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
