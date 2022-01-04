using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    private NavMeshAgent _agent;
    private GameObject _playerModel;
    private CharacterController _characterController;

    public float Nav_StoppingDistance { get { return _agent.stoppingDistance; } }


    private void Awake()
    {
        _characterController = this.GetComponentInChildren<CharacterController>();
        _agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Vector3 point,float speed,float maxspeed)
    {
        _agent.destination = point;
        _agent.speed = maxspeed * Mathf.Clamp01(speed);

        Debug.Log("이동 중");

        if (_agent.remainingDistance <=0)
        {
            Debug.Log("멈춤");
        }
    }


}
