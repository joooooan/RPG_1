using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_UI : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("Disable");
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1.0f);

        this.gameObject.SetActive(false);
    }

}

