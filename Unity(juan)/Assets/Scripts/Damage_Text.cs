using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage_Text : MonoBehaviour
{
    Text text; //데미지 텍스트

    private void Awake()
    {
        text = this.GetComponent<Text>(); 
    }

    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.2f);

        this.gameObject.SetActive(false);
    }

}
