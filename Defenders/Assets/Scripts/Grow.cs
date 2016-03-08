using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Grow : MonoBehaviour {


    public GameObject bombPrefab;
    private GameObject bomb;
    private bool bombCD;
    public int bombCDLength = 10;

    //UI elements
    public Text clock;
    public Text scorer;
    public Text gameOver;
    //...the time...
    public int timeRemaining;

    void Awake()
    {
        //rerences needed later
    }

	void Start () {

    }
	
	void Update () {

        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene(0);
        }
    }

    //ends game
    void LateUpdate()
    {
        if(timeRemaining <= 0)
        {
            endGame();
        }
    }
    //shows gameOver text and stops game time
    void endGame()
    {
        Color col = gameOver.GetComponent<Text>().color;
        col.a = 1f;
        gameOver.GetComponent<Text>().color = col;
        Time.timeScale = 0;
    }
}
