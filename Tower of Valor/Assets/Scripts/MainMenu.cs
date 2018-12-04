using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene1 ()
    {
		FindObjectOfType<AudioManager> ().Mute ("MainMenu");
		FindObjectOfType<AudioManager> ().UnMute ("Theme");
		//FindObjectOfType<AudioManager>().Play("LavaRising");
		//FindObjectOfType<AudioManager>().Play("FireBurning");

		//FindObjectOfType<AudioManager>().Mute("LavaRising");
		//FindObjectOfType<AudioManager>().Mute("FireBurning");
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void LoadScene2()
    {
		FindObjectOfType<AudioManager> ().Mute ("MainMenu");
		FindObjectOfType<AudioManager> ().UnMute ("Theme");
		//FindObjectOfType<AudioManager>().Play("LavaRising");
		//FindObjectOfType<AudioManager>().Play("FireBurning");

		//FindObjectOfType<AudioManager>().Mute("LavaRising");
		//FindObjectOfType<AudioManager>().Mute("FireBurning");
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

	void Start()
	{
		//FindObjectOfType<AudioManager> ().Play ("MainMenu");
	}
}
