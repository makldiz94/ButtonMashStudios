using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    private Transform target;
    public bool inRange;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
        euler = transform.eulerAngles;
        look = target.transform.position - this.transform.position;
        euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = euler;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //Debug.Log("Player in range");
            inRange = true;
        }
        
        if (col.gameObject.tag == "Bomb")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Player out of range");
            inRange = false;
        }
    }
    private void Shoot() {
        if (!inRange)
        {
            return;
        }
        else
        {            
            GameObject shot = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
            shot.transform.eulerAngles = this.transform.eulerAngles;
        }
    }
}
