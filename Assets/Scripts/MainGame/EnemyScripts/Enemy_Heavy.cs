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

    //public Player p;




    // Start is called before the first frame update

    //enemy need access to player to call the take damage method
    void Start()
    {
        //p = GameObject.Find("Player");
        //p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        this.transform.rotation = Quaternion.Euler(180f, 90f,180f);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        Physics.IgnoreLayerCollision(7,7);
    }





    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        //Debug.Log(p);

        //-1f                 
        this.transform.Translate(new Vector3(-1f, UnityEngine.Random.Range(-0.1f, 0.1f),0f) * speed * Time.deltaTime, null);
        
        //

        /*if (this.gameObject.transform.position.x <= 0)
        {
            Destroy(this.gameObject);
            p.takeDamage(damage);
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.takeDamage(damage);
            Destroy(this.gameObject);
        }


    }
}
