using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene1 ()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void LoadScene2()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
