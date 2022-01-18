using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBox : MonoBehaviour
{

    private bool _findPlayer;

    private GameObject _player;

    public bool FindPlayer { get { return _findPlayer; } set { _findPlayer = value; } }

    private void Start()
    {
        _findPlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _findPlayer = true;

            _player = other.gameObject;

            //Debug.Log(_player.transform.position);

            Debug.Log("플레이어 발견");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _findPlayer = false;

            Debug.Log("플레이어 놓침");
        }
    }

    public GameObject GetPlayer()
    {
        return _player;
    }
}

