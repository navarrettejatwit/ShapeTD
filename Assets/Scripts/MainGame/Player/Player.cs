using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

    
{


    private Rigidbody2D rb;
    public int health;
    public int maxHealth;


// Start is called before the first frame update
void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        health = maxHealth;

        this.gameObject.SetActive(true);
        /*if (audioSource != null)
        {
            audioSource.volume = 1f;
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }
        */
    }

    public void takeDamage(int value)
    {

        health -= value;
        GameManager.instance().updatePlayerHealth(health);


        if (health <= 0)
        {
            //player dies
            this.gameObject.SetActive(false);
            //GameManager.instance().deathPanelSwitch(true);
            Time.timeScale = 0f;
        }
    }


}
