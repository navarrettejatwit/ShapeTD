using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    private BadGuy e;
    
    private Transform SpawnPoint;

    private GameObject badGuys;

    public EnemyFactory(BadGuy e, GameObject badGuys)
    {
        this.e = e;
        this.badGuys = badGuys;
    }

    public Product produce()
    {
        return spawn(e, SpawnPoint, badGuys);
    }

    private Product spawn(BadGuy e, Transform esp, GameObject badGuys)
    {
        return Object.Instantiate(e, new Vector3(esp.position.x, esp.position.y, 0f), Quaternion.identity, badGuys.transform);
    }

    public void setSpawnPoint(Transform esp)
    {
        SpawnPoint = esp;
    }
}
