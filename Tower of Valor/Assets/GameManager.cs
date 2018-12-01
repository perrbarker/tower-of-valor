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
        SceneManager.LoadScene("Main Menu");
    }

    void Restart()
    {

    }
}
