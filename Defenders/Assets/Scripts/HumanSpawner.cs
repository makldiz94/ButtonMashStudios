using UnityEngine;
using System.Collections;

public class HumanSpawner : MonoBehaviour {

    public int humanCount;
    public GameObject humanPrefab;

    void Start()
    {
        SpawnHuman();
    }

    void SpawnHuman()
    {
        for(int i = 0; i < humanCount; i++)
        {
            Vector3 rand = Random.insideUnitCircle * 5;
            GameObject person = Instantiate(humanPrefab, transform.position, Quaternion.identity) as GameObject;
            person.transform.position += rand;
        }
    }
}
