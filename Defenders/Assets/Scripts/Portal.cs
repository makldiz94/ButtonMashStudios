using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public GameObject[] possibleExits;
	public bool canTele;
	public int teleCooldown;
	private Transform trans;
	private GameObject currentExit;
	public int RangeNum;


	//Portal Audio
	public AudioClip portal;
	private AudioSource portalSource;


	// Use this for initialization
	void Start () {
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		portalSource = allAudioSources [4];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit){
		if (hit.CompareTag ("Portal")) {
			if (canTele) {

				int rand = Random.Range(0, RangeNum);
				//Pick an exit
				currentExit = possibleExits[rand];

				//Don't teleport to the same portal you entered through
				/*if (currentExit.transform.position == hit.transform.position) {
					System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject> (possibleExits);
					list.Remove (currentExit);
					possibleExits = list.ToArray ();
				}*/
					
					//possibleExits.RemoveAt (1);
			
				//Go to the picked exit's location
				trans = currentExit.transform;
				transform.position = trans.position;

				//Full ship audio
				portalSource.clip = portal;
				portalSource.Play ();
				canTele = false;

				//Invoke ("ResetTele", teleCooldown);
			}
	
		}
	}

	void OnTriggerExit2D(Collider2D hit){
		if (hit.CompareTag ("Portal")) {
			canTele = true;
			}

		}




	/*void ResetTele(){
		canTele = true;
	}*/
}
