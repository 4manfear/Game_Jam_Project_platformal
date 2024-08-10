using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectiable : MonoBehaviour
{
    [SerializeField]
    private GameObject connect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("2dPlayer"))
        {
            connect.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }


}
