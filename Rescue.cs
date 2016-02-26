using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rescue : MonoBehaviour {
	public GameObject[] humans;
	public int playerScore;
	public int redCounter = 0;
	public int blueCounter = 0;
	public int yellowCounter = 0;
	public int blackCounter = 0;
	//bools start off false
	public bool fullShip;

	void Start(){
		if 
		for (int i=0; i < humans.length; i++) {
		}
	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Human")) {
			if (fullShip == true) {
				return;
			} else {
				switch (hit.gameObject.GetComponent<Human>().col)
				{
				case "red":
					redCounter++;
					break;
				case "blue":
					blueCounter++;
					break;
				case "yellow":
					yellowCounter++;
					break;
				case "black":
					blackCounter++;
					break;
				}

				if (redCounter + blueCounter + yellowCounter + blackCounter > 3) {
					fullShip = true;
				}


			}
		}

		if (hit.CompareTag ("Planet")) {
				switch (hit.gameObject.GetComponent<Planet>().col){
					case "red":
					playerScore += (redCounter * 100);
					redCounter = 0;
				blueCounter = 0;
					break;
					case "blue":
					playerScore += (blueCounter * 100);
					blueCounter = 0;
					break;
					case "yellow":
					yellowCounter = 0;
						break;
					case "black":
					blackCounter = 0;
						break;
			}
			//counters have to be reset
			//get planet color, compare color to color counters
			//if planet color is blue, look at blue counter
			//fullship has to be not true

		}

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

	void addScore (int num)
			switch(num)
			{
			case 0:
			playerScore += 100;
				Console.WriteLine("Case 0 +100");
				break;
			case 1:
			playerScore += 500;
				Console.WriteLine("Case 1 +500");
				break;
			case 2:
			playerScore += 1000;
				Console.WriteLine("Case 2 +1000");
			default:
			playerScore += 0;
				Console.WriteLine("Default case +0");
				break;
			}




}