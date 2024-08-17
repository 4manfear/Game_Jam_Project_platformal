using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credit_scene : MonoBehaviour
{
    public GameObject startmenu, creditmenu;


    public void tocreditscene()
    {
        startmenu.SetActive(false);
        creditmenu.SetActive(true);
    }

    public void tomainmenu()
    {
        startmenu.SetActive(true);
        creditmenu.SetActive(false);
    }

}
