using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    public int health;
    public float speed;
    public GameObject target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        euler = transform.eulerAngles;
        look = target.transform.position - this.transform.position;
        this.transform.position += look.normalized * speed * Time.deltaTime;
        euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = euler;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Debug.Log("Enemy destroyed by player");
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Planet")
        {
            Debug.Log("Enemy destroyed by planet");
            Destroy(gameObject);
        }
    }
}
