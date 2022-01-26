using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MP : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        slider = this.GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = (float)PlayerDataManager.Instance.Player._CurrMp / (float)PlayerDataManager.Instance.Player._MaxMp;
    }

}
