using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not sure what this script had some useful stuff, changed it to Player1
//original name use to be Player, but then we would have duplicate objects.
//Some useful stuff in here for future implemenation.
public class Player1 : MonoBehaviour
{

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    public Animator anim;
    private int maxHealth;
    private int health;

    public GameObject gunshotObject;
    public GameObject bulletObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;
        audioSource.clip = audioClips[3];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        health = maxHealth;
        this.transform.position = new Vector3(-0.03f, 0.49f, 0f);
        this.gameObject.SetActive(true);
        if (audioSource != null)
        {
            audioSource.volume = 1f;
            audioSource.clip = audioClips[3];
            audioSource.Play();
        }

    }

    public void takeDamage(int value)
    {

        health -= value;
        //GameManager.instance().updatePlayerHealth(health);
        audioSource.volume = 1f;
        audioSource.clip = audioClips[2];
        audioSource.Play();

        if (health <= 0)
        {
            //player dies
            this.gameObject.SetActive(false);
            //GameManager.instance().deathPanelSwitch(true);
            Time.timeScale = 0f;
        }
    }
}
