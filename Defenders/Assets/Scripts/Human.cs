using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Human : MonoBehaviour {
	public Text humanText;
	public int totalHumans1 = 0;
	public int totalHumans2 = 0;
	public Animator animator;
	
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	
	void Start(){
		UpdateHumanText();
		
	}
	
	void OnTriggerEnter2D(Collider2D hit){
		//In Inspector, as in life, please tag humans as "humans".
		//if colliding with human, destroy it and add one to list of humans you are carrying
		//also activate animator boolean to display human floating around you... now what?
		if (hit.CompareTag ("Human1")) {
			totalHumans1++;
			UpdateHumanText ();
			Destroy (hit.gameObject);
			//animation test
			animator.SetBool ("FloatingHuman", true);
			
		} else if (hit.CompareTag ("Human2")) {
			totalHumans2++;
			UpdateHumanText ();
			Destroy (hit.gameObject);
		}
		//In Inspector, tag drop zone for humans "Earth".
		//if colliding with earth, remove all humans from list and disable floating humans animation
		else if (hit.CompareTag ("Earth1")) {
			totalHumans1 = 0;
			UpdateHumanText ();
			animator.SetBool ("FloatingHuman", false);
		} else if (hit.CompareTag ("Earth2")) {
			totalHumans2 = 0;
			UpdateHumanText ();
			
		}
	}
	
	public void UpdateHumanText(){
		string humanMessage = "humans1 = " + totalHumans1 + ", humans2 = " + totalHumans2;
		humanText.text = humanMessage;
		if (totalHumans1 == 0)
			animator.SetBool("FloatingHuman", false);
	}
	
	
}