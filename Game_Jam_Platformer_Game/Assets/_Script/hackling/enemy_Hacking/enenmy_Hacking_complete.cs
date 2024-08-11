using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enenmy_Hacking_complete : MonoBehaviour
{

    [SerializeField]
    private GameObject crackedthecode;

    [Header("enemy script")]
    [SerializeField]
    private Enemy enemy1,enemy2;

    [Header("level")]
    [SerializeField]
    private GameObject  towdlevel, threedlevel, player1;

    [SerializeField]
    private GameObject enemydistructioneffect1, enemydistructioneffect2;

    private void Update()
    {
        if (crackedthecode.activeSelf)
        {
            towdlevel.SetActive(false);
            threedlevel.SetActive(true);
            player1.SetActiveRecursively(true);
            enemy1.GetComponent<Enemy>().enabled = false;
            enemy2.GetComponent<Enemy>().enabled = false;
            enemydistructioneffect1.SetActive(true);
            enemydistructioneffect2.SetActive(true);
        }
    }
}
