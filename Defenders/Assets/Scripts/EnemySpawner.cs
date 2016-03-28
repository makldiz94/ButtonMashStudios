using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public int enemyCount;
    public GameObject[] enemyPrefabs;

    public int enemySpawnRate;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(transform.parent == player.transform)
        {
            Debug.Log("Player is parent");
            InvokeRepeating("SpawnEnemy", 5f, enemySpawnRate);
        }
        else
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 rand = Random.insideUnitCircle;
            rand.x = 5 * rand.x + (Mathf.Sign(rand.x) * 4);
            rand.y = 5 * rand.y + (Mathf.Sign(rand.y) * 4);
            int which = Random.Range(0, 2);
            GameObject enemy = Instantiate(enemyPrefabs[which], transform.position, Quaternion.identity) as GameObject;
            enemy.transform.position += rand;
        }
    }
}
