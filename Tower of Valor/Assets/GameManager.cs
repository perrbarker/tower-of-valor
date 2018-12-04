using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public Text gameOverText;
	public Text congratsText;
    public TextMeshProUGUI congrats;
    public void GameOver()

    {
        gameOverText.text = "Game Over";
        Invoke("MainMenu", 5f);
    }

	public void Congratulations()
	{
        congrats.SetText("Congratulations!                         You Win!");
        Invoke ("MainMenu", 5f);
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
