using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    private Enemy e;

    private Transform SpawnPoint;

    private GameObject Enemies;

    public EnemyFactory(Enemy e, GameObject Enemies)
    {
        this.e = e;
        this.Enemies = Enemies;
    }

    public Product produce()
    {
        return spawn(e, SpawnPoint, Enemies);
    }

    private Product spawn(Enemy e, Transform esp, GameObject Enemies)
    {
        return Object.Instantiate(e, new Vector3(esp.position.x, esp.position.y, 0f), Quaternion.identity, Enemies.transform);
    }

    public void setSpawnPoint(Transform esp)
    {
        SpawnPoint = esp;
    }
}
