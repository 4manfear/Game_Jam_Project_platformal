using UnityEngine;

public class enenmy_Hacking_completeed : MonoBehaviour
{
    [SerializeField]
    private Animator[] anim;

    [SerializeField]
    private GameObject rackedthecode;

    [Header("enemy script")]
    [SerializeField]
    private Enemy enemy1l,enemy2l;

    [Header("level")]
    [SerializeField]
    private GameObject  towdlevell, threedlevell, player1l;

    [SerializeField]
    private GameObject enemydistructioneffect1l, enemydistructioneffect2l;

    private void Update()
    {
        if (rackedthecode.activeSelf)
        {
            anim[0].SetFloat("movement_Cuntroller", 2f);
            anim[1].SetFloat("movement_Cuntroller", 2f);

            towdlevell.SetActive(false);
            threedlevell.SetActive(true);
            player1l.SetActive(true);
            enemy1l.GetComponent<Enemy>().enabled = false;
            enemy2l.GetComponent<Enemy>().enabled = false;
            enemydistructioneffect1l.SetActive(true);
            enemydistructioneffect2l.SetActive(true);

            Destroy(towdlevell);
            
        }
    }
}
