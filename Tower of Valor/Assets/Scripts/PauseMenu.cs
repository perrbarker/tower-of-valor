using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void load2Players()
    {
        Time.timeScale = 1f;
        Debug.Log("2Players");
        SceneManager.LoadScene(2);
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("mainmenu");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quitgame");
        Application.Quit();
    }
}
