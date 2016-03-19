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
    private int startHealth = 10;
    public int curHealth;
    private Transform child;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";


    public bool untouchable;

	void Start () {
        curHealth = startHealth;
	}
	
	void FixedUpdate () {
        move();

        if(curHealth < 1)
        {
            //SceneManager.LoadScene(2);
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!untouchable)
        {
            if (col.gameObject.tag == "Enemy")
            {
                TakeDamage(1);
            }

            if (col.gameObject.tag == "Enemy2")
            {
                TakeDamage(2);
            }
        }
    }

    void TakeDamage(int enemyType)
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

    private IEnumerator invincible()
    {
        untouchable = true;
        Color col = GetComponent<SpriteRenderer>().color;
        col.a = .5f;
        GetComponent<SpriteRenderer>().color = col;
        yield return new WaitForSeconds(2f);
        col.a = 1f;
        GetComponent<SpriteRenderer>().color = col;
        untouchable = false;
    }
}
