using UnityEngine;
using System.Collections;

public class WorldEdge : MonoBehaviour {

	public GameObject player;
	public Rigidbody2D pbody;
	private Player pscript;
	private Shoot shoot;
	private Transform pform;

	//WorldEdge Audio
	public AudioClip bounds;
	private AudioSource boundsSource;

	// Use this for initialization
	void Start () {
		pbody = player.GetComponent<Rigidbody2D> ();
		pform = player.GetComponent<Transform> ();
		pscript = player.GetComponent<Player>();
		shoot = player.GetComponent<Shoot>();

		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		boundsSource = allAudioSources [6];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		boundsSource.clip = bounds;
		boundsSource.Play ();
		if (coll.gameObject.tag == "Right") {
			//Debug.Log ("Player hit wall at " + pbody.velocity);
			//Debug.Log(pform.x);
			StartCoroutine (RightWait ());
			//Debug.Log ("Player velocity is: " + pbody.velocity);
		} 
		else if (coll.gameObject.tag == "Left") {

			StartCoroutine (LeftWait ());
		}
		else if (coll.gameObject.tag == "Top") {

			StartCoroutine (TopWait ());
		}
		else if (coll.gameObject.tag == "Bottom") {

			StartCoroutine (BottomWait ());
		}
		else if (coll.gameObject.tag == "TL") {

			StartCoroutine (TLWait ());
		}
		else if (coll.gameObject.tag == "TR") {

			StartCoroutine (TRWait ());
		}
		else if (coll.gameObject.tag == "BL") {

			StartCoroutine (BLWait ());
		}
		else if (coll.gameObject.tag == "BR") {

			StartCoroutine (BRWait ());
		}
		/*elseif (coll.gameObject.tag == "Bottom"){
			
		}
		else if (coll.gameObject.tag == "Top"){
		}*/
	}

	IEnumerator RightWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce(-Vector2.right * 150);
		pform.rotation = Quaternion.Euler (0, 0, 90);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 

	IEnumerator LeftWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		//Alternatively, move player towards origin for a set period of time vvv		
		//transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(0,0), 3);
		pbody.AddForce(Vector2.right * 150);
		pform.rotation = Quaternion.Euler (0, 0, -90);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 

	IEnumerator TopWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce(Vector2.down * 150);
		pform.rotation = Quaternion.Euler (0, 0, 180);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 

	IEnumerator BottomWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce(Vector2.up * 150);
		pform.rotation = Quaternion.Euler (0, 0, 0);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 
	IEnumerator TLWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce((Vector2.down * 150)+(Vector2.right * 150));
		pform.rotation = Quaternion.Euler (0, 0, 228);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 
	IEnumerator TRWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce((Vector2.down * 150)+(-Vector2.right * 150));
		pform.rotation = Quaternion.Euler (0, 0, 140);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 
	IEnumerator BLWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce((Vector2.up * 150)+(Vector2.right * 150));
		pform.rotation = Quaternion.Euler (0, 0, 312);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 
	IEnumerator BRWait()
	{
		//Disable player control and push them away from the edge of the wall for a certain amount of time
		pbody.AddForce((-Vector2.down * 150)+(-Vector2.right * 150));
		pform.rotation = Quaternion.Euler (0, 0, 45);
		pscript.enabled = false;
		shoot.enabled = false;

		yield return new WaitForSeconds(1.5f);

		pscript.enabled = true;
		shoot.enabled = true;
		pbody.velocity = new Vector2 (0, 0);
	} 
}
