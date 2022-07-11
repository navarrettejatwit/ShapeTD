using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float travelSpeed;
    public int Damage;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       this.transform.Translate(.05f, 0, Time.deltaTime);
       rigidBody.transform.Translate(.05f, 0, Time.deltaTime);
    }
    public void onTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 7)
        {
           
            /* This needs to be finished alongside enemies
             * Essentially we just recieve the enemy hit out of the enemy controller/spawner and do the damage
             * Below is the line that needs to be fixed with correct references
             /**/
           // collision.gameObject.GetComponent<BadGuys>().ReceiveDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
