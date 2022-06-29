using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //private List<Enemy> allEnemies = new List<Enemy>();

    [SerializeField] private GameObject enemies = null;

    [SerializeField] private int enemyPerWave = 0;

    [SerializeField] private GameObject EnemySpawnPoints;

    public float timeBetween = 0;

    public float spawnTime = 0;

    private EnemyFactory Enemy_Factory;

    private Transform[] SpawnPoints = null;

    private Transform SpawnPoint;

    private bool needSpawnPoint = false;

    private int spawnLocation = 0;



    public List<BadGuy> badGuys;
    public List<GameObject> badGuyPrefabs;




    // Start is called before the first frame update
    void Start()
    {
        Enemy_Factory = new EnemyFactory(badGuyPrefabs, badGuys);
        SpawnPoints = GameObject.FindGameObjectWithTag("EnemySpawnPoints").GetComponentsInChildren<Transform>();
        needSpawnPoint = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*spawnTime -= Time.deltaTime;
        spawnWave();*/

        foreach (BadGuy badguy in badGuys)
        {
            if (badguy.isSpawned == false && badguy.spawnTime <= Time.time)
            {
                Instantiate(badGuyPrefabs[(int)badguy.enemyType], transform.GetChild(badguy.Spawner).transform);
                badguy.isSpawned = true;
            }
        }

    }

    //Would reset the spawner, but might not be needed.
    public void reset()
    {

    }

    //Spawns enemies
    public void spawnWave()
    {
        if (spawnTime <= 0f)
        {
            BadGuy e;
            for (int i = 0; i < enemyPerWave; i++)
            {
                getSpawnPoint();
                Enemy_Factory.setSpawnPoint(SpawnPoint);
                e = (Enemy) Enemy_Factory.produce();
                //allEnemies.Add(e);
            }

            spawnTime = timeBetween;
        }
    }

    public List<Enemy> getAllEnemies(){
     return allEnemies
    }

    public void removeEnemy(Enemy e)
    {
        allEnemies.Remove(e);
    }

    public void getSpawnPoint()
    {
        if (needSpawnPoint)
        {
            spawnLocation = Random.Range(1, SpawnPoints.Length);
        }
        SpawnPoint = SpawnPoints[spawnLocation];
    */
    }

}
