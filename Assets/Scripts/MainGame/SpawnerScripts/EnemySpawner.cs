using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    //private List<Enemy> allEnemies = new List<Enemy>();

    [SerializeField] private Enemy EnemyPrefab;

    [SerializeField] private Enemy EnemyPrefab1;

	[SerializeField] private GameObject enemies = null;

    [SerializeField] private int enemyPerWave = 0;

    public float timeBetween = 0;

    public float spawnTime = 0;

    private EnemyFactory Enemy_Factory;

    private EnemyFactory Enemy_Factory1;

    private Transform[] SpawnPoints = null;

    private Transform SpawnPoint;

    private bool needSpawnPoint = false;
    public TextMeshProUGUI enemyCount;
    public TextMeshProUGUI waveCountUI;
    private int i = 0;
    private int waveNumber =0;

    // Start is called before the first frame update
    void Start()
    {
        /**Enemy factory constructor called.
         *
         * EnemyPrefab: Light Enemy
         * EnemyPrefab1: Heavy Enemy
         */

        Enemy_Factory = new EnemyFactory(EnemyPrefab, enemies);
        Enemy_Factory1 = new EnemyFactory(EnemyPrefab1, enemies);
        
        SpawnPoints = GameObject.FindGameObjectWithTag("EnemySpawnPoints").GetComponentsInChildren<Transform>();
        needSpawnPoint = true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        spawnWave();
        enemyCount.text = "Enemies: "+enemies.transform.childCount;

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
            Enemy e;
            waveNumber++;
            waveCountUI.text = "Wave: " + waveNumber;
            for (int i = 0; i < enemyPerWave; i++)
            {
                getSpawnPoint();
                if (i > 10)
                {
                    Enemy_Factory1.setSpawnPoint(SpawnPoint);
                    e = (Enemy) Enemy_Factory1.produce();                        
                    e.transform.rotation = Quaternion.Euler(new Vector3(180, 90, 180));
                }
                else
                {
                    Enemy_Factory.setSpawnPoint(SpawnPoint);
                    e = (Enemy) Enemy_Factory.produce();
                    e.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                }
            }

            spawnTime = timeBetween;
        }
    }

    public void getSpawnPoint()
    {
        if (needSpawnPoint)
        {
            i = Random.Range(1, SpawnPoints.Length);
        }
        SpawnPoint = SpawnPoints[i];
    }

}
