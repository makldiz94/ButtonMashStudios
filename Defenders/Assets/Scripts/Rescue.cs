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

    public Text scoreText;
	
    //bools start off false
	public bool fullShip;
	
	void OnTriggerEnter2D(Collider2D hit){

        if (hit.CompareTag("Human"))
        {
            Debug.Log("Collided with human");

            if (fullShip == true)
            {
                return;
            }
            else
            {
                switch (hit.gameObject.GetComponent<HumanColorize>().col)
                {
                    case "blue":
                        IceCounter++;
                        break;
                    case "red":
                        LavaCounter++;
                        break;
                    case "green":
                        GasCounter++;
                        break;
                    case "white":
                        SaturnCounter++;
                        break;
                    case "yellow":
                        EggCounter++;
                        break;
                }
                Destroy(hit.gameObject);
            }
            if (LavaCounter + GasCounter + SaturnCounter + EggCounter + IceCounter >= 3)
            {
                fullShip = true;
            }            
        }

        else if (hit.CompareTag("Planet"))
        {
            Debug.Log("collided with planet");

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
        }
        else
        {
            Debug.Log("What the hell. " + hit.gameObject.name);
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