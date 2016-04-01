using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Counts up collected humans
//Adds score based on drop-off planet
//Planets tagged planet, "Color" attribute comes in Lava, Ice, Egg, Saturn, and Gas


public class Rescue : MonoBehaviour {

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
		alienSource = allAudioSources [0];
		fullshipSource = allAudioSources [1];
		dropoffSource = allAudioSources [2];
	}

	void OnTriggerEnter2D(Collider2D hit){

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
                    case "green":
                        GasCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                    case "white":
                        SaturnCounter++;
                        humanHold[curHumanCount].SetActive(true);
                        humanHold[curHumanCount].GetComponent<SpriteRenderer>().color = Color.white;
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
		playerScore += ((totalHumans - num) * 10) + (num * 100);
        SetScore();
	}

    void SetScore()
    {
        scoreText.text = "" + playerScore.ToString();
    }
}