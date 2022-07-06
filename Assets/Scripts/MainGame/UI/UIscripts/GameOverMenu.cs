using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject GameOverMenuUI = null;

    [SerializeField] private GameObject Player = null;
    
    void Update()
    {
        //if (Player.getHealth == 0)
        //{
            GameOverMenuUI.SetActive(true);
            Time.timeScale = 0f;
        //}
    }
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
