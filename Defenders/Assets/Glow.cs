using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour {

	private float glower = 50;
	private Color col;
	public float speed = .1f;
	public bool rising;

	// Use this for initialization
	void Start () {
		col = GetComponent<SpriteRenderer> ().color;
		Debug.Log (col.a);
		StartCoroutine (Fade ());
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (!rising) {
			if (col.a == glower) {
				rising = true;
			}
			col.a -= Mathf.Lerp (col.a, glower, Time.deltaTime * speed);
			Debug.Log (col.a);
			GetComponent<SpriteRenderer> ().color = col;
		}
		else {
			if (col.a == 1) {
				rising = false;
			}
			col.a += Mathf.Lerp (glower, 1, Time.deltaTime * speed);
			GetComponent<SpriteRenderer> ().color = col;
		}*/
	}

	IEnumerator Fade(){
		for (int i = 0; i < glower; i++) {
			col.a -= .01f; 
			GetComponent<SpriteRenderer> ().color = col;
			yield return new WaitForSeconds (.01f);
		}

		StartCoroutine (Brighten ());
	}

	IEnumerator Brighten(){
		for (int i = 0; i < glower; i++) {
			col.a += .01f;
			GetComponent<SpriteRenderer> ().color = col;
			yield return new WaitForSeconds (.01f);
		}

		StartCoroutine (Fade ());
	}
}
