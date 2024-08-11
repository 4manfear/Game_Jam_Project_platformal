using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opengate : MonoBehaviour
{
    private opengate op;
    [SerializeField]
    private GameObject pas1, pas2, pas3;
    [SerializeField]
    private GameObject door,door1, towdlevel1, threedlevel,player1;
    private void Awake()
    {
        op = GetComponent<opengate>();
    }
    private void Update()
    {
        if (pas1.activeSelf && pas2.activeSelf && pas3.activeSelf)
        {
            Destroy(door);
            Destroy(door1);
            Destroy(towdlevel1);
            threedlevel.SetActive(true);
            player1.SetActive(true);
            Destroy(this.gameObject);
        }


    }
}
