using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public int enemyCount;
    public GameObject[] enemyPrefabs;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 rand = Random.insideUnitCircle * 8;
            int which = Random.Range(0, 2);
            GameObject enemy = Instantiate(enemyPrefabs[which], transform.position, Quaternion.identity) as GameObject;
            enemy.transform.position += rand;
        }
    }
}
