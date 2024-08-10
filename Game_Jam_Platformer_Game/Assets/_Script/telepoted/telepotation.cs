using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telepotation : MonoBehaviour
{
    [SerializeField]
    private Transform p1, p2,player;
   

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
               
            
             if (IsCloseTo(transform.position, p2.position))
            {
                player.position = p1.position;
            }
        }
    }

    private bool IsCloseTo(Vector3 position1, Vector3 position2, float threshold = 2f)
    {
        return Vector3.Distance(position1, position2) < threshold;
    }
}
