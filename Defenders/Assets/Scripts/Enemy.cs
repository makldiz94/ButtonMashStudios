using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy destroyed");
            Destroy(gameObject);
        }
    }
}
