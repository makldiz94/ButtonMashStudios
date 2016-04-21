using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public int enemyCount;
    public GameObject[] enemyPrefabs;

    private List<GameObject> enemiesLimit;

    public float enemySpawnRate;

    public float ramp;

    void Awake()
    {
        
    }
    void Start()
    {
        ramp += Time.time;
        InvokeRepeating("SpawnEnemy", 5f, enemySpawnRate);
    }

    void FixedUpdate()
    {
        if(Time.time > ramp)
        {
            ramp += ramp;
            enemyCount++;
        }
    }

    void SpawnEnemy()
    {
        GameObject[] enemyCounter = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemyCounter.Length < 100)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 rand = Random.insideUnitCircle;
                rand.x = 5 * rand.x + (Mathf.Sign(rand.x) * 4);
                rand.y = 5 * rand.y + (Mathf.Sign(rand.y) * 4);
                int which = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = Instantiate(enemyPrefabs[which], transform.position + rand, Quaternion.identity) as GameObject;
            }
        }
    }
}
