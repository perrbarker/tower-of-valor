using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Text gameOverText;
    
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        Invoke("MainMenu", 2.5f);
    }

    void MainMenu()
    {
		FindObjectOfType<AudioManager> ().Stop ("Theme");
		FindObjectOfType<AudioManager>().Play("MainMenu");

		FindObjectOfType<AudioManager>().Mute("LavaRising");
		FindObjectOfType<AudioManager>().Mute("FireBurning");
        SceneManager.LoadScene("Main Menu");
    }

    void Restart()
    {

    }
}
