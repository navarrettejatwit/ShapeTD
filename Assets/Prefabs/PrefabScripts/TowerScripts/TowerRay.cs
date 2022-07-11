using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wizard tower, shoots a powerful particle whatever at them enemy. I recommend using raycast.
public class TowerRay : MonoBehaviour
{
    public GameObject bullet;
    public List<GameObject> enemies;
    public GameObject toAttack;
    public float waitTime;
    private float attackTime;
    public int DamageValue;
    public bool isAttacking;
    public bool isHitscan;
    public bool isSplash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0 && isAttacking == false)
        {
            isAttacking = true;
        }
        else if(enemies.Count == 0 && isAttacking == true)
        {
            isAttacking = false;
        }
        if (toAttack != null)
        {
            if(attackTime <= Time.time)
            {
               GameObject bulletInstance = Instantiate(bullet, transform);
                bulletInstance.GetComponent<BulletLogic>().Damage = DamageValue;
                attackTime = Time.time + waitTime;
            }
        }
    }
}
