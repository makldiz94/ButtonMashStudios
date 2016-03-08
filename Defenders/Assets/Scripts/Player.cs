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
    
    public float speed;
    private int startHealth = 10;
    public int curHealth;
    private Transform child;

    public bool untouchable;

	void Start () {
        child = transform.GetChild(0);
        curHealth = startHealth;
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
        float up = Input.GetAxis("Vertical");                                           //Get the vertical axis set in Unity editor
        float side = Input.GetAxis("Horizontal");                                       //Get the vertical axis set in Unity editor

        Vector3 moving = new Vector3(side, up, 0f);                                     //set up V3 based on inputs
        float angle = Mathf.Atan2(side, up) * Mathf.Rad2Deg;                            //create a float, set equal to the Atan2 of side and up

        if (moving != Vector3.zero) {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            child.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }

        transform.Translate(moving * speed * Time.deltaTime,Space.World);
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
