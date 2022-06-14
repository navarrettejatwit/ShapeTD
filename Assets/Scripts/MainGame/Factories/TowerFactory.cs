using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : Factory
{
    private Tower t;
    
    private Transform SpawnPoint;

    public TowerFactory(Tower t)
    {
        this.t = t;
    }

    public Product produce()
    {
        return spawn(t, SpawnPoint);
    }

    private Product spawn(Tower t, Transform tsp)
    {
        return Object.Instantiate(t, new Vector3(tsp.position.x, tsp.position.y, 0f), Quaternion.identity);
    }

    public void setSpawnPoint(Transform tsp)
    {
        SpawnPoint = tsp;
    }
}
