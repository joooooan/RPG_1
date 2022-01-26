using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Dungeon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LoadManager.LoadScene("HomeScene");
        }
    }
}
