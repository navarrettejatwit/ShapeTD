using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Basci : MonoBehaviour
{
    private float speed;
    public float minSpeed;
    public float maxSpeed;
    public int damage;
    public int health;

    // Start is called before the first frame update
    void Start()
    {                                                       //2f
        this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        Physics.IgnoreLayerCollision(7,7);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {                                       //-1f                                      , 0.1f)
        this.transform.Translate(new Vector3(1f, UnityEngine.Random.Range(-0.1f, 0.1f),0f) * speed * Time.deltaTime);

        /*if (this.gameObject.transform.position.x <= 0)
        {
            Destroy(this.gameObject);
        }
*/
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
