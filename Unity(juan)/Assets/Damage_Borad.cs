using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage_Borad : MonoBehaviour
{
    Text text;

    public int damage;

    private void Start()
    {
        text = this.GetComponentInChildren<Text>();
        setTextDamage(damage);
        StartCoroutine(Disable());
    }

    void Update()
    {
        this.transform.forward = Camera.main.transform.forward;
        this.transform.position += Vector3.up * 0.5f * Time.deltaTime;

    }

    public void setTextDamage(int damage)
    {
        Debug.Log(damage);
        text.text = damage.ToString();
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.1f);

;        Color color = text.color;

        for(float i = 1.0f; i >= 0.0f; i -= 0.12f)
        {
            color.a = i;
            text.color = color;

            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.0f);

        Destroy(this.gameObject);

    }
}
