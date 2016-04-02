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
    
    public float speed = 1.0f;
    private int startHealth = 25;
    public int curHealth;
    private Transform child;

    public Slider hp;
    public string horizontalAxis = "ShootX";
    public string verticalAxis = "ShootY";

    public bool untouchable;

	//Player Death Audio
	public AudioClip damaged;
	private AudioSource damagedSource;


	void Start () {
        curHealth = startHealth;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		damagedSource = allAudioSources [3];
	}
	
	void FixedUpdate () {
        move();

        if(curHealth < 1)
        {
            SceneManager.LoadScene("GameOver");
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
            //Debug.Log("Shooter hit player");
            TakeDamage(2);
        }
    }

    public void TakeDamage(int enemyType)
    {
        if (!untouchable)
        {
            StartCoroutine(invincible());
            switch (enemyType)
            {
                case 1:
                    Debug.Log("Case 1 ran, enemy hit player");
                    curHealth--;
                    hp.value = curHealth;
                    break;
                case 2:
                    Debug.Log("Case 2 ran, enemy hit player");
                    curHealth -= 2;
                    hp.value = curHealth;
                    break;
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
}
