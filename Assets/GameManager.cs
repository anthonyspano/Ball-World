using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // in-game menu
    public GameObject mainMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
        }
    }
}
