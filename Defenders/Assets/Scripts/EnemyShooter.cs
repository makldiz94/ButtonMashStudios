using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

    public int speed;
    private Vector3 euler;
    private Vector3 look;
    private Transform target;
    public bool inRange;
    public bool chasing;
    public GameObject bulletPrefab;

    public GameObject[] explosions;

	//Enemy Shooter Audio
	public AudioClip shooterdeath;
	private AudioSource shooterdeathSource;
	public AudioClip shooterfire;
	private AudioSource shooterfireSource;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 1f, .5f);
		//ShooterAudio
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		shooterdeathSource = allAudioSources [0];
		shooterfireSource = allAudioSources [1];
        chasing = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (chasing && target != null)
        {
            euler = transform.eulerAngles;
            look = target.transform.position - this.transform.position;
            euler.z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = euler;

            if (!inRange)
            {
                this.transform.position += look.normalized * speed * Time.deltaTime;
            }
        }        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            Destroy(this.gameObject);
			StartCoroutine (OnDeath ());
        }

        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            target.GetComponent<Rescue>().addScoreEnemy(100);
            StartCoroutine(OnDeath());
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Sun")
        {
            Debug.Log("Sun Hit");
            Death();
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
            //Destroy(this.gameObject);
			StartCoroutine (OnDeath ());
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
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
			shooterfireSource.clip = shooterfire;
			shooterfireSource.Play ();
        }
    }

	IEnumerator OnDeath()
	{
        chasing = false;
        //Play enemy death sound and then destroy
        GetComponent<CircleCollider2D>().enabled = false;
        shooterdeathSource.clip = shooterdeath;
		shooterdeathSource.Play ();
		inRange = false;
        GameObject explosion1 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion2 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion3 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        GameObject explosion4 = Instantiate(explosions[Random.Range(0, explosions.Length)], transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion1, 2f);
        Destroy(explosion2, 2f);
        Destroy(explosion3, 2f);
        Destroy(explosion4, 2f);
        yield return new WaitForSeconds(.5f);
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject); 
	} 
}
