using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

	void Start()
	{
		/*
		if (FindObjectOfType<AudioManager> ().IsPlaying ("Theme"))
		{
			FindObjectOfType<AudioManager> ().Play ("LavaRising");
			FindObjectOfType<AudioManager> ().Play ("FireBurning");

			FindObjectOfType<AudioManager> ().Mute ("LavaRising");
			FindObjectOfType<AudioManager> ().Mute ("FireBurning");
			return;
		}
		else
		{
		*/
			//FindObjectOfType<AudioManager> ().UnMute ("Theme");
			//FindObjectOfType<AudioManager> ().Play ("LavaRising");
			//FindObjectOfType<AudioManager> ().Play ("FireBurning");

			//FindObjectOfType<AudioManager> ().Mute ("LavaRising");
			//FindObjectOfType<AudioManager> ().Mute ("FireBurning");
		//}
	}
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

	public void load1Players()
	{
		Time.timeScale = 1f;
		Debug.Log("1Player");
		FindObjectOfType<AudioManager> ().Mute ("LavaRising");
		FindObjectOfType<AudioManager> ().Mute ("FireBurning");
		FindObjectOfType<AudioManager>().UnMute("Theme");
		SceneManager.LoadScene(1);
	}

    public void load2Players()
    {
        Time.timeScale = 1f;
        Debug.Log("2Players");
		FindObjectOfType<AudioManager> ().Mute ("LavaRising");
		FindObjectOfType<AudioManager> ().Mute ("FireBurning");
		FindObjectOfType<AudioManager>().UnMute("Theme");
        SceneManager.LoadScene(2);
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("mainmenu");
		FindObjectOfType<AudioManager>().Mute("Theme");
		FindObjectOfType<AudioManager>().UnMute("MainMenu");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("quitgame");
        Application.Quit();
    }
}
