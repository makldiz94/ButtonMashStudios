using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
    Handles player
        movement
        collisions
        stats
*/
public class Player : MonoBehaviour {
    
    public float speed = 1.0f;
    private int startHealth = 5;
    public int curHealth;
    private Transform child;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public bool untouchable;

	//Player Death Audio
	public AudioClip damaged;
	private AudioSource damagedSource;


	void Start () {
        curHealth = startHealth;
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		damagedSource = allAudioSources [6];
	}
	
	void FixedUpdate () {
        move();

        if(curHealth < 1)
        {
            SceneManager.LoadScene(2);
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
			//damagedSource.clip = damaged;
			//damagedSource.Play ();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
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
                    break;
                case 2:
                    Debug.Log("Case 2 ran, enemy hit player");
                    curHealth -= 2;
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

        yield return new WaitForSeconds(2f);
        col.g = 1f;
        col.b = 1f;
        GetComponent<SpriteRenderer>().color = col;
        untouchable = false;
    }
}
