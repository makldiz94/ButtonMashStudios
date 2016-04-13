using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    Handles player
        movement
        collisions
        stats
*/
public class Player : MonoBehaviour {

    public float speed;
    public float startingSpeed = 5f;
    public int startHealth = 25;
    public int curHealth;
    private Transform child;

    public Slider hp;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public bool untouchable;
    public bool dead;

    public GameObject bug;

    public GameObject[] explosions;

	//Player Death Audio
	public AudioClip damaged;
	private AudioSource damagedSource;


	void Start () {
        curHealth = startHealth;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		damagedSource = allAudioSources [3];
        speed = startingSpeed;
	}
	
	void FixedUpdate () {
        if (!dead)
        {
            move();
        }

        if (curHealth < 1)
        {
            dead = true;          
        }

        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }

    }

    void move()
    {
        transform.position += (Vector3.right * Input.GetAxis(horizontalAxis) + Vector3.up * Input.GetAxis(verticalAxis)).normalized * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Planet")
        {
            Debug.Log("You hit planet " + col.gameObject.name);
			
        }
        if(col.gameObject.tag == "BulletEnemy")
        {
            TakeDamage(1);
        }
    }

    public void Bug()
    {
        if (bug.activeInHierarchy)
        {
            speed /= 2;
        }
        Invoke("Squash", 5f);
    }

    void Squash()
    {
        bug.SetActive(false);
        speed = startingSpeed;
        TakeDamage(3);
    }

    public void TakeDamage(int damage)
    {
        if (!untouchable)
        {
            StartCoroutine(invincible());
            curHealth -= damage;
            hp.value = curHealth;
            if(curHealth <= 0)
            {
                Die();
            }
        }
    }


    private IEnumerator invincible()
    {
		//Damaged audio
		damagedSource.clip = damaged;
		damagedSource.Play ();

        untouchable = true;
        Color col = GetComponent<SpriteRenderer>().color;
        col.g = .5f;
        col.b = .5f;
        GetComponent<SpriteRenderer>().color = col;

        yield return new WaitForSeconds(1f);
        col.g = 1f;
        col.b = 1f;
        GetComponent<SpriteRenderer>().color = col;
        untouchable = false;
    }

    void Die()
    {
        Instantiate(explosions[0], transform.position, Quaternion.identity);
        Instantiate(explosions[1], transform.position, Quaternion.identity);
        Instantiate(explosions[2], transform.position, Quaternion.identity);
        Instantiate(explosions[3], transform.position, Quaternion.identity);
        Invoke("LoseScene", 2);
    }

    void LoseScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
