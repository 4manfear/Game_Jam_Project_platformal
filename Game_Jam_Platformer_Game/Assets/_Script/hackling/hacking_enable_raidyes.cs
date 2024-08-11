using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacking_enable_raidyes : MonoBehaviour
{
    [SerializeField]
    GameObject playerr;
    [SerializeField]
    private GameObject threed_Environment, _Player, twodenvironment;
    [SerializeField]
    private GameObject UI_Intraction;
    [SerializeField]
    private bool canhack;
    [SerializeField]
    private float detectionrange;

    private void Awake()
    {
        UI_Intraction.SetActive(false);

    }


    private void Start()
    {
       
    }

    private void Update()
    {
        playerr = GameObject.FindWithTag("Player");

        float distanceToPlayer = Vector3.Distance(transform.position, playerr.transform.position);

        if (distanceToPlayer <= detectionrange)
        {
            UI_Intraction.SetActive(true);
            canhack = true;
        }
        if (distanceToPlayer > detectionrange)
        {
            UI_Intraction.SetActive(false);
            canhack = false;
        }

        if (canhack)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UI_Intraction.SetActive(false);
                threed_Environment.SetActive(false);
                _Player.SetActive(false);
                twodenvironment.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Set the color for the gizmo
        Gizmos.color = Color.red;

        // Draw a wireframe sphere at the object's position with a radius of detectionrange
        Gizmos.DrawWireSphere(transform.position, detectionrange);
    }
}
