using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomPauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    
   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
   
   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
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
