using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Hp : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)PlayerDataManager.Instance.Player._CurrHp / (float)PlayerDataManager.Instance.Player._MaxHp;
    }
}
