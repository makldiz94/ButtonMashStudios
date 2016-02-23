using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Grow : MonoBehaviour {

    //Player score
    public float score;
    //Instantiated Object
    public GameObject prefab;
    private GameObject shield;
    //shield cooldown bool and time
    private bool shieldCD;
    public int shieldCDlength = 10;

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
        StartCoroutine(theClock());
    }
	
	void Update () {

        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene(0);
        }

        //On button press, make a shield around ship
        if (Input.GetKeyDown("g") && shieldCD == false)
        {
            shieldCD = true;
            shield = Instantiate(prefab, this.transform.position, Quaternion.identity) as GameObject;
            StartCoroutine(CoolDown());
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

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(shieldCDlength);
        shieldCD = false;
    }

    //Game Timer
    IEnumerator theClock()
    {
        timeRemaining--;
        SetTime();
        yield return new WaitForSeconds(1f);
        StartCoroutine(theClock()); //recursive
    }

    //Update the time UI
    void SetTime()
    {
        clock.text = timeRemaining.ToString();
    }

    //Update the score UI
    void SetScore()
    {
        scorer.text = score.ToString();
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
