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
    
   
}

public enum EnemyType
{
    Enemy_Light,
    Enemy_Heavy
}

