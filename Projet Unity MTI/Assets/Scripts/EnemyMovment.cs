using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    public int damage;
    private NavMeshAgent _navMeshAgent;
    private Transform _destination;

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
        List<GameObject> l = new List<GameObject>(GameObject.FindGameObjectsWithTag("SolarPanel"));
        l.Add(GameObject.FindWithTag("Player"));
        _destination = GetClosestEnemy(l.ToArray());
    
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

    private Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.GetComponent<Transform>().position, currentPos);
            if (dist < minDist)
            {
                tMin = t.GetComponent<Transform>();
                minDist = dist;
            }
        }
        return tMin;
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
