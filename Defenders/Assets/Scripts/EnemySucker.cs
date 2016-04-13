using UnityEngine;
using System.Collections;

public class EnemySucker : MonoBehaviour {

    private Vector3 euler;
    private Vector3 look;
    public int health;
    public float speed;
    public GameObject target;
    public GameObject scorePrefab;
    public bool chasing;

    private int points = 100;

    public GameObject[] explosions;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
        chasing = true;
    }

    void FixedUpdate()
    {
        if (chasing && target != null)
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
            if (health <= 0)
            {
                Destroy(col.gameObject);
                StartCoroutine(Die());
            }
            else
            {
                Destroy(col.gameObject);
                health--;
            }
        }
        if (col.gameObject.tag == "Sun")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Infest();
            Death();           
        }
    }

    void Infest()
    {
        Debug.Log("infesting");
        target.transform.GetChild(3).transform.gameObject.SetActive(true);
        target.GetComponent<Player>().Bug();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Death();           
        }
    }

    IEnumerator Die()
    {
        target.GetComponent<Rescue>().addScoreEnemy(100);
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject explosion1 = Instantiate(explosions[Random.Range(0, 3)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion2 = Instantiate(explosions[Random.Range(0, 3)], transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion1, 2f);
        Destroy(explosion2, 2f);
        
        chasing = false;
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
