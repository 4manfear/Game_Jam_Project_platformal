using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   private NavMeshAgent agent;
    [SerializeField]private Transform PointA, PointB;
    [SerializeField]
    private float mindis;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        agent.SetDestination(PointA.position);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, PointA.position) < mindis)
        {
            agent.destination = PointB.position;
        }
        if (Vector3.Distance(transform.position, PointB.position) < mindis)
        {
            agent.destination = PointA.position;
        }

    }
}
