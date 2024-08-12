using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacking_enable_raidyes : MonoBehaviour
{
    public enenmy_Hacking_complete ehc;

    [SerializeField]
    private threed_Player_Movement _PlayerMovement;
    [SerializeField]
    private GameObject threed_Environment, playerHolder, twodenvironment;
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
        //playerr = GameObject.FindWithTag("Player");

        if (_PlayerMovement)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _PlayerMovement.transform.position);

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
        }

        if (canhack)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                twodenvironment.SetActive(true);


                // Destroy(this.gameObject);
                //gameObject.SetActive(false);
                //_PlayerMovement._is2Denabled = true;
            }



        }

        if(twodenvironment.activeSelf)
        {
            UI_Intraction.SetActive(false);
            threed_Environment.SetActive(false);
            playerHolder.SetActive(false);
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
