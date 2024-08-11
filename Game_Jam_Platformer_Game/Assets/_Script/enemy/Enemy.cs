using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private Transform PointA, PointB;
    [SerializeField] private float mindis = 1f; // Minimum distance to switch points
    [SerializeField] private float detectionRange = 10f; // Range at which the enemy detects the player
    [SerializeField] private float detectionAngle = 45f; // Angle of detection (field of view)
    [SerializeField] private LayerMask playerLayer; // Layer of the player
    [SerializeField] private LayerMask obstacleLayer; // Layer of obstacles that can block the raycast

    private GameObject player;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent.SetDestination(PointA.position);
    }

    private void Update()
    {
        if (PlayerInSight())
        {
            // Chase the player
            agent.SetDestination(player.transform.position);
        }
        else
        {
            // Patrol between PointA and PointB
            PatrolBetweenPoints();
        }
    }

    private bool PlayerInSight()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Check if the player is within the detection range
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRange)
        {
            // Check if the player is within the detection angle
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleToPlayer <= detectionAngle / 2f)
            {
                // Perform a raycast to see if there is a clear line of sight
                if (!Physics.Raycast(transform.position, directionToPlayer, detectionRange, obstacleLayer))
                {
                    // Player is within range, within the field of view, and not obstructed by obstacles
                    return true;
                }
            }
        }

        return false;
    }

    private void PatrolBetweenPoints()
    {
        // If close to PointA, move to PointB
        if (Vector3.Distance(transform.position, PointA.position) < mindis)
        {
            agent.SetDestination(PointB.position);
        }
        // If close to PointB, move to PointA
        else if (Vector3.Distance(transform.position, PointB.position) < mindis)
        {
            agent.SetDestination(PointA.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw detection range sphere
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw detection angle lines
        Vector3 leftBoundary = Quaternion.Euler(0, -detectionAngle / 2, 0) * transform.forward * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, detectionAngle / 2, 0) * transform.forward * detectionRange;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
