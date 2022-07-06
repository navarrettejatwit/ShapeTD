using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class Enemy : MonoBehaviour, Product
{

    public EnemyType enemyType;
    public int spawnTime;
    public int Spawner;
    public bool RandomSpawn;
    public bool isSpawned;


    /*public int getSpeed()
    {
        return this.speed;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }


}
    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(-1f, UnityEngine.Random.Range(-0.1f, 0.1f), 0f) * speed * Time.deltaTime);
    }*/

}



public enum EnemyType
{
    Enemy_Light,
    Enemy_Heavy
}
