using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    public int health;
    public float speed;
    public GameObject target;

    public bool chasing;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (chasing)
        {
            euler = transform.eulerAngles;
            look = target.transform.position - this.transform.position;
            this.transform.position += look.normalized * speed * Time.deltaTime;
            euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = euler;
        }
        else
        {
            //Patrolling
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Bomb")
        {
            Debug.Log("Enemy destroyed by player");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Planet")
        {
            Debug.Log("Enemy destroyed by planet");
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Player")
        {
            chasing = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            chasing = true;
        }

        if(col.gameObject.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            chasing = false;
        }
    }
}
