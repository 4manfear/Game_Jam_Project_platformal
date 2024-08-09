using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_switcher : MonoBehaviour
{
    [SerializeField]
    private GameObject fpp_Player;
    [SerializeField]
    private GameObject twoDCamera;
    public bool fppistrue;

    private void Start()
    {
        fppistrue = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(fppistrue)
            {
                fppistrue = false;
                fpp_Player.SetActive(false);
                twoDCamera.SetActive(true);
            }
            
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!fppistrue)
            {
                fppistrue = true;
                fpp_Player.SetActive(true);
                twoDCamera.SetActive(false);
            }
        }
    }
}
