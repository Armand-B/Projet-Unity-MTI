using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Transform _destination;

    // Start is called before the first frame update
    void Start()
    {
        _destination = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void SetDestination()
    {
        _destination = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent != null)
        {
            SetDestination();
        }
    }
}
