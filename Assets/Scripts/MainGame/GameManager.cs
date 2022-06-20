using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }

    //health bar
    /*public void updatePlayerHealth(int health)
    {

        if (health > 0)
        {
            playText.text = "x" + health;
        }
        else playText.text = "0";

    }*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void deathPanelSwitch(bool state)
    {
        deathPanel.SetActive(state);
    }
    */


    public void Reset()
    {
        //player.Reset();
        //spawner.Reset();
        //house.Reset();
        //GameManager.instance().updateHouseHealth(house.maxHealth);
        //GameManager.instance().updatePlayerHealth(player.maxHealth);
        //deathPanelSwitch(false);  
        Time.timeScale = 1f;
    }

}
