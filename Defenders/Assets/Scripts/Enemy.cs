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

    public GameObject[] explosions;

	//Enemy Audio
	public AudioClip enemy;
	private AudioSource enemySource;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		enemySource = allAudioSources [0];
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
            Destroy(col.gameObject);
			StartCoroutine (OnDeath ());
            target.GetComponent<Rescue>().addScoreEnemy(50);
        }
        if (col.gameObject.tag == "Sun")
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            target.GetComponent<Player>().TakeDamage(1);
            StartCoroutine(OnDeath());
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            StartCoroutine(OnDeath());
        }
    }

	IEnumerator OnDeath()
	{
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject explosion1 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion2 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion1, 1f);
        Destroy(explosion2, 1f);
        //Play enemy death sound and then destroy
        enemySource.clip = enemy;
		enemySource.Play ();
		chasing = false;
		yield return new WaitForSeconds(.5f);       
        Destroy(this.gameObject); 
	} 
}
