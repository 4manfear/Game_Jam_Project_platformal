using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_sceen_switcher : MonoBehaviour
{
    [SerializeField]
    private int sceenswitchnumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceenswitchnumber);
        }
    }

}
