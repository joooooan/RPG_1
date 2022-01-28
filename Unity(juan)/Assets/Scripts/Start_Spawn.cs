using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Spawn : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerDataManager.Instance._isRest)
        {

        }
        else
        {
            PlayerManager.Instance._player.transform.position = this.transform.position;
        }
    }

}
