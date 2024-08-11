using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trigger_To_Gate_One : MonoBehaviour
{
    [SerializeField]
    private GameObject threed_Environment, _Player, twodenvironment;
    [SerializeField]
    private GameObject UI_Intraction;
    [SerializeField]
    private bool canhack;

    private void Awake()
    {
        UI_Intraction.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_Intraction.SetActive(true);
            canhack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_Intraction.SetActive(false);
            canhack = false;
        }
    }
    private void Update()
    {
        if(canhack)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UI_Intraction.SetActive(false);
                threed_Environment.SetActive(false);
                _Player.SetActive(false);
                twodenvironment.SetActive(true);
            }
        }
    }
}
