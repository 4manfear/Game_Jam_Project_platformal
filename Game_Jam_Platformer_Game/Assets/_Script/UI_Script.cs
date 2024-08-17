using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public void Playthegame_mudit()
    {
        SceneManager.LoadScene(1);
    }
    public void backtohome_Mudit()
    {
        SceneManager.LoadScene("start_sceen");
    }
    public void quit_Mudit()
    {
        Application.Quit();
    }
    public void levelrestarter_Mudit()
    {
        SceneManager.LoadScene(1);
    }
    

}
