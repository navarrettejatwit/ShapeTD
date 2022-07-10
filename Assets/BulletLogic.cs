using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float travelSpeed;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(travelSpeed, 0, 0));
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
