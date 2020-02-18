using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject _pauseMenuUI;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();

        }

        void Pause()
        {
            _pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            GameIsPaused = true;
        }
    }

        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
            GameIsPaused = false;
        }

}

