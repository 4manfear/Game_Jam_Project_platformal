using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    enemy_ded_and_not_ded ednd;

    [SerializeField]
    private Animator anim;

    private NavMeshAgent agent;

    [SerializeField] private Transform PointA, PointB;
    [SerializeField] private float mindis = 1f; // Minimum distance to switch points
    [SerializeField] private float detectionRange = 10f; // Range at which the enemy detects the player
    [SerializeField] private float detectionAngle = 45f; // Angle of detection (field of view)
    [SerializeField] private LayerMask playerLayer; // Layer of the player
    [SerializeField] private LayerMask obstacleLayer; // Layer of obstacles that can block the raycast

    [SerializeField]
    private GameObject player;

    private AudioSource audioSource;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ednd = GetComponent<enemy_ded_and_not_ded>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
      
        agent.SetDestination(PointA.position);
    }

    private void Update()
    {
        if (player)
        {
            player = GameObject.FindWithTag("Player");
        }

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
        if (player)
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
                    anim.SetFloat("movement_Cuntroller", 1f);
                    // Perform a raycast to see if there is a clear line of sight
                    if (!Physics.Raycast(transform.position, directionToPlayer, detectionRange, obstacleLayer))
                    {
                        // Player is within range, within the field of view, and not obstructed by obstacles
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private void PatrolBetweenPoints()
    {
        anim.SetFloat("movement_Cuntroller", 0f);

        // Check the current destination and move to the other point if necessary
        if (Vector3.Distance(transform.position, PointA.position) < mindis)
        {
            agent.SetDestination(PointB.position);
            HandleEnemyMovementSound(true); // Play sound if patrolling
        }
        else if (Vector3.Distance(transform.position, PointB.position) < mindis)
        {
            agent.SetDestination(PointA.position);
            HandleEnemyMovementSound(true); // Play sound if patrolling
        }
        else
        {
            HandleEnemyMovementSound(false); // Stop sound if idle
        }
    }

    private void HandleEnemyMovementSound(bool isMoving)
    {
        if (isMoving && !audioSource.isPlaying)
        {
            audioSource.Play(); // Start playing the audio if the enemy is moving
        }
        else if (!isMoving && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio if the enemy is not moving
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(ednd.cancaught == true)
            {
                SceneManager.LoadScene(5);
            }
        }
    }


}
