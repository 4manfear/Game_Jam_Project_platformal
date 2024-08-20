using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public GameObject pausemenucan;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pausemenucan.SetActive(true);
        }
    }

    public void resume_button()
    {
        Time.timeScale = 1f;
        pausemenucan.SetActive(false);
    }

    public void goingbackhome()
    {
        SceneManager.LoadScene(0);
    }

}
