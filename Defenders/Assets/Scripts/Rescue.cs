using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Counts up collected humans
//Adds score based on drop-off planet
//Planets tagged planet, "Color" attribute comes in Lava, Ice, Egg, Saturn, and Gas


public class Rescue : MonoBehaviour {
	public GameObject[] humans;
	public int playerScore;
	public int LavaCounter = 0;
	public int IceCounter = 0;
	public int EggCounter = 0;
	public int SaturnCounter = 0;
	public int GasCounter = 0;
	//bools start off false
	public bool fullShip;
	public string testhuman;
	public string testplanet;

	void Start(){
		/*for (int i=0; i < humans.length; i++) {
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Human")) {
			Debug.Log ("Collided with human");
			if (fullShip == true) {
				return;
			} 

			else {
				switch (testhuman)
				//switch (hit.gameObject.GetComponent<Human>().col)
				{
				case "Ice":
					IceCounter++;
					break;
				case "Lava":
					LavaCounter++;
					break;
				case "Gas":
					GasCounter++;
					break;
				case "Saturn":
					SaturnCounter++;
					break;
				case "Egg":
					EggCounter++;
					break;
				}

				if (LavaCounter + GasCounter + SaturnCounter + EggCounter + IceCounter > 3) {
					fullShip = true;
				}


			}
		}
			
		if (hit.CompareTag ("Planet")) {
			Debug.Log ("collided with planet");
				//switch (hit.gameObject.GetComponent<Planet>().col){
			switch (testplanet){
			case "Ice":
				addScore (IceCounter);
					break;
			case "Lava":
				addScore (LavaCounter);
					break;
			case "Gas":
				addScore (GasCounter);
					break;
			case "Saturn":
				addScore (SaturnCounter);
					break;
			case "Egg":
				addScore (EggCounter);
				break;
			}

			IceCounter = 0;
			LavaCounter = 0;
			GasCounter = 0;
			SaturnCounter = 0;
			EggCounter = 0;

			//counters have to be reset
			//get planet color, compare color to color counters
			//if planet color is blue, look at blue counter
			//fullship has to be not true

		}

		else Debug.Log("What the hell.");

	}
		/*
			int index = humans.Length;
			humans[index] =
			
			if (humans.Length = 3) {
				break;
			}
			else 
			/* counter = 0;
			 * for (human.Curcolor  = planet.Curcolor)
			 * counter++ 
			 */
	//take account for total number of passengers


	void addScore (int num)
	{
		int totalHumans = IceCounter + LavaCounter + GasCounter + EggCounter + SaturnCounter;
		//Calculate and add points. 10*# of non-matching + 100*matching
		switch (num) {
		case 0:
			playerScore += ((totalHumans - num) * 10) + (num * 100);
			break;
		case 1:
			playerScore += ((totalHumans - num) * 10) + (num * 100);
			break;
		case 2:
			playerScore += ((totalHumans - num) * 10) + (num * 100);
			break;
		default:
			playerScore += ((totalHumans - num) * 10) + (num * 100);
			break;
		}
	}




}