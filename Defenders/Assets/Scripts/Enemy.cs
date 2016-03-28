using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    public int health;
    public float speed;
    public GameObject target;
    public GameObject scorePrefab;
    public bool chasing;

    private int points = 100;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 dist = transform.position - target.transform.position;        
    }

    void LateUpdate()
    {
        if (chasing)
        {
            euler = transform.eulerAngles;
            look = target.transform.position - this.transform.position;
            this.transform.position += look.normalized * speed * Time.deltaTime;
            euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = euler;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "Bomb")
        {
            Debug.Log("Enemy destroyed by player");
            OnDeath();
        }

        if (col.gameObject.tag == "Planet")
        {
            Debug.Log("Enemy destroyed by planet");
            OnDeath();
        }

        if(col.gameObject.tag == "Player")
        {
            chasing = true;
        }

        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            OnDeath();
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
            OnDeath();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            chasing = false;
        }
    }

    public void OnDeath()
    {
        //GameObject scoreShow = Instantiate(scorePrefab, this.transform.position, Quaternion.identity) as GameObject;
        //scoreShow.transform.parent = GameObject.Find("Canvas2").transform;
        //scoreShow.GetComponent<Text>().text = "" + points;
        Destroy(this.gameObject);      
    }
}
