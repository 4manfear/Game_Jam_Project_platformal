using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void changescene_MUDIT()
    {
        SceneManager.LoadScene(0);
    }
}
