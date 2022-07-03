using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Heavy : MonoBehaviour
{
    private float speed;
    public float minSpeed;
    public float maxSpeed;
    public int damage;
    public int health;

    // Start is called before the first frame update
    void Start()
    {                                                       //0f
        this.transform.rotation = Quaternion.Euler(0f, 180f, 2f);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {                                       //-1f                 
        this.transform.Translate(new Vector3(1f, UnityEngine.Random.Range(-0.1f, 0.1f)) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.takeDamage(damage);
            Destroy(this.gameObject);
        }*/


    }
}
