using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpHuman : MonoBehaviour {
	public Text humanText;
	public int totalHumans = 0;
	public Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	void Start(){
		UpdateHumanText();

	}

	void OnTriggerEnter2D(Collider2D hit){
		//if colliding with human, destroy it and add one to list of humans you are carrying
		//also activate animator boolean to display human floating around you... now what?
		if (hit.CompareTag ("Human")) {
			totalHumans++;
			UpdateHumanText ();
			Destroy (hit.gameObject);
			//animation test
			animator.SetBool ("FloatingHuman", true);
		//if colliding with earth, remove all humans from list and disable floating humans animation
		} else if (hit.CompareTag ("Earth")) {
			totalHumans = 0;
			UpdateHumanText ();
			animator.SetBool ("FloatingHuman", false);
		}
	}

	public void UpdateHumanText(){
		string humanMessage = "humans = " + totalHumans;
		humanText.text = humanMessage;
		if (totalHumans == 0)
			animator.SetBool("FloatingHuman", false);
	}


}