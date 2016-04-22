using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Counts up collected humans
//Adds score based on drop-off planet
//Planets tagged planet, "Color" attribute comes in Lava, Ice, Egg, Saturn, and Gas


public class Rescue : MonoBehaviour {

    public GameObject scorer;
    public Text remainingText;
    public int remainingHumans = 30;

    public int playerScore;
	private int LavaCounter = 0;
	private int IceCounter = 0;
	private int EggCounter = 0;
	private int SaturnCounter = 0;
	private int GasCounter = 0;
    public int curHumanCount;
    public GameObject[] humanHold;
    public bool fullShip;

    [Header("Audio")]
    private AudioSource[] allAudioSources;
	private AudioSource alienSource;
	private AudioSource fullshipSource;
	private AudioSource dropoffSource;
	public AudioClip fullship;
	public AudioClip pickupalien;
	public AudioClip dropoff;

    public Text scoreText;
	
    //bools start off false

	void Start (){
		//AudioSource Array
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		alienSource = allAudioSources [9];
		fullshipSource = allAudioSources [10];
		dropoffSource = allAudioSources [11];
	}

    void Update()
    {
        if (remainingHumans == 0 || Input.GetKeyDown("t"))
        {
            Debug.Log("GG");
            SceneManager.LoadScene("Win");
        }
    }

	void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Human"))
        {
            //Debug.Log("Collided with human");

            if (fullShip == true)
            {
				//full ship Audio
				fullshipSource.clip = fullship;
				fullshipSource.Play ();
                return;
            }
            else
            {
				//Pick Up Audio
				alienSource.clip = pickupalien;
				alienSource.Play ();
                switch (hit.gameObject.GetComponent<HumanColorize>().col)
                {
                    case "blue":
                        IceCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.blue;
                        break;
                    case "red":
                        LavaCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case "brown":
                        GasCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        Color colo = Color.white;
                        colo.r = 146f;
                        colo.g = 102f;
                        colo.b = 0f;
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = colo;
                        break;
                    case "green":
                        SaturnCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case "yellow":
                        EggCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                }
                Destroy(hit.gameObject);
            }
            curHumanCount = LavaCounter + GasCounter + SaturnCounter + EggCounter + IceCounter;
            if (curHumanCount >= 5)
            {
                fullShip = true;
            }            
        }

        else if (hit.CompareTag("Planet"))
        {
            //Debug.Log("collided with planet");
            if (curHumanCount > 0)
            {
                switch (hit.gameObject.name)
                {
                    case "IcePlanet":
                        addScore(IceCounter);
                        break;
                    case "LavaPlanet":
                        addScore(LavaCounter);
                        break;
                    case "GasPlanet":
                        addScore(GasCounter);
                        break;
                    case "SaturnPlanet":
                        addScore(SaturnCounter);
                        break;
                    case "EggPlanet":
                        addScore(EggCounter);
                        break;
                }
                IceCounter = 0;
                LavaCounter = 0;
                GasCounter = 0;
                SaturnCounter = 0;
                EggCounter = 0;
                fullShip = false;
                for(int i = 0; i < curHumanCount; i++)
                {
                    humanHold[i].SetActive(false);  
                }
                curHumanCount = 0;
                dropoffSource.clip = dropoff;
                dropoffSource.Play();
            }
        }
        else
        {
            //Debug.Log("What the hell. " + hit.gameObject.name);
        }
	}

	void addScore (int num)
	{
		int totalHumans = IceCounter + LavaCounter + GasCounter + EggCounter + SaturnCounter;
		//Calculate and add points. 10*# of non-matching + 100*matching
		playerScore += ((totalHumans - num) * 10) + (num * 500);
        SetScore();
        remainingHumans -= totalHumans;
        SubtractScore();
	}

    public void addScoreEnemy(int num)
    {
        playerScore += num;
        SetScore();
    }

    void SubtractScore()
    {
        remainingText.text = "Remaining Humans: " + remainingHumans.ToString() + " of 30";
    }

    void SetScore()
    {
        scoreText.text = "" + playerScore.ToString();
        scorer.GetComponent<Scoring>().score = playerScore;
    }
}