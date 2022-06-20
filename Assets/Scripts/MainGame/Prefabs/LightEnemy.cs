using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{

    private float speed;
    private int health;
    private int damage;
    private float minSpeed;
    private float maxSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(-1f, UnityEngine.Random.Range(-0.1f, 0.2f), 0f) * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.takeDamage(damage);
            Destroy(this.gameObject);
        }
        if (collision.tag == "bullet")
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            
            // type of bullet this.health -= b.getDamage();
            Destroy(this.gameObject);
        }
    }


}
