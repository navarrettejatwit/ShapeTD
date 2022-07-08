using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenuButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
