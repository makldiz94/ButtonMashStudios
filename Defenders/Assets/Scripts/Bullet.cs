using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 move = Vector3.up;
        move *= Time.deltaTime * speed;
        transform.Translate(move, Space.World);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
