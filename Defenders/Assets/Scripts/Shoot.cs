using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space pressed");
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
	}
}
