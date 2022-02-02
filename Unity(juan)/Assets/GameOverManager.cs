using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text gameover_text;

    public GameObject continue_text;

    private void Start()
    {
        StartCoroutine(enable());
    }

    IEnumerator enable()
    {
        yield return new WaitForSeconds(0.1f);

        Color color = gameover_text.color;

        for (float i = 0; i < 1; i += 0.05f)
        {
            color.r = i;
            gameover_text.color = color;

            yield return new WaitForSeconds(0.1f);
        }

        continue_text.SetActive(true);

    }

}
