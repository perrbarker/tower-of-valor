using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text gameOverText;
	public Text congratsText;
    
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        Invoke("MainMenu", 2.5f);
    }

	public void Congratulations()
	{
		//congratsText.text = "Hooray!/n" + "You defeated the Evil Wizard!";
		Invoke ("MainMenu", 2.5f);
	}

    void MainMenu()
    {
		FindObjectOfType<AudioManager> ().Mute ("Theme");
		FindObjectOfType<AudioManager>().Mute("LavaRising");
		FindObjectOfType<AudioManager>().Mute("FireBurning");
		FindObjectOfType<AudioManager>().UnMute("MainMenu");
        SceneManager.LoadScene("Main Menu");
    }

    void Restart()
    {

    }
}
