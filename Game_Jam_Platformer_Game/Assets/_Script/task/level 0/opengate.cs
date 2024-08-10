using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opengate : MonoBehaviour
{
    [SerializeField]
    private GameObject pas1, pas2, pas3;
    [SerializeField]
    private GameObject door,door1,towdlevel,threedlevel,player1; 

    private void Update()
    {
        if (pas1.activeSelf && pas2.activeSelf && pas3.activeSelf)
        {
            Destroy(door);
            Destroy(door1);
            towdlevel.SetActive(false);
            threedlevel.SetActive(true);
            player1.SetActive(true);
        }


    }
}
