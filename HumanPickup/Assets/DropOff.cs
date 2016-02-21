using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DropOff : MonoBehaviour {

	public Text humanText;
	public int totalHumans = 0;
	
	void Start(){
		UpdateHumanText();
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag ("Earth")){
			totalHumans=0;
			UpdateHumanText();
			//
		}
	}
	
	public void UpdateHumanText(){
		string humanMessage = "humans = " + totalHumans;
		humanText.text = humanMessage;
	}
}