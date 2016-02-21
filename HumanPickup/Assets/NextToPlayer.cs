using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextToPlayer : MonoBehaviour {
	private GameObject playerChar;
	private Vector3 playerCharPos;
	private float speed = 6.0f;

	void Update(){
		playerChar = GameObject.Find ("Player");
	}

	void OnTriggerEnter2D(Collider2D hit){
		if(hit.CompareTag ("Player")){
			//remove collider so that score is unchanged as humans follow you??
			//Collider.enabled = false;
			playerCharPos = new Vector3(playerChar.transform.position.x +3, playerChar.transform.position.y, playerChar.transform.position.z);
			transform.position = Vector3.MoveTowards (transform.position, playerCharPos, speed * Time.deltaTime);

			//
		}
	}
}

