using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenuUI = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
