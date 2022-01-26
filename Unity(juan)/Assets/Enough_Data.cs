using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enough_Data : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.3f);
    }

}
