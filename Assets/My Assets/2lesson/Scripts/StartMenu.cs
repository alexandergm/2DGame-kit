using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        Application.LoadLevel(2);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

    
}
