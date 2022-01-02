using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float _playerSpeed = 5;


    private GameObject _playerModel;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = this.GetComponentInChildren<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Vector3 direction)
    {


        this.transform.position += direction * _playerSpeed * Time.deltaTime;

        this.transform.LookAt(this.transform.position + direction);
    }
}
