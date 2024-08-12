using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy_ded_and_not_ded : MonoBehaviour
{
    [SerializeField]
    private int sceneloadernum =5;

    

    
    public Enemy enemy;

    
    public bool cancaught;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetComponent<Enemy>().enabled == true)
        {
            cancaught = true;
        }
        else
        {
            cancaught=false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(cancaught)
            {
                SceneManager.LoadScene(sceneloadernum);
            }
        }
    }
}
