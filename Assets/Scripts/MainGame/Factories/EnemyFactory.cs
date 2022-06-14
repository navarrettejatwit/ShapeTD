using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    private Enemy e;
    
    private Transform SpawnPoint;

    public EnemyFactory(Enemy e)
    {
        this.e = e;
    }

    public Product produce()
    {
        return spawn(e, SpawnPoint);
    }

    private Product spawn(Enemy e, Transform esp)
    {
        return Object.Instantiate(e, new Vector3(esp.position.x, esp.position.y, 0f), Quaternion.identity);
    }

    public void setSpawnPoint(Transform esp)
    {
        SpawnPoint = esp;
    }
}
