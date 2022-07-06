using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speedBulet = 15f;
    public Rigidbody2D rb;

    private GameObject gunshoot;
    private GameObject playerObject;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gunshoot = GameObject.FindGameObjectWithTag("GunShot");
        playerObject = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * speedBulet;
        if (playerObject.transform.position.x > gunshoot.transform.position.x)
        {
            rb.velocity = -transform.right * speedBulet;
        }
        else
        {
            rb.velocity = transform.right * speedBulet;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HeavyEnemy")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "LightEnemy")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "enemy")
        {
            audioSource.Play();
            StartCoroutine(delayDestroyObject());
        }
    }

    IEnumerator delayDestroyObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

}
