using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject[] possibleExits;
	public bool canTele;
	public float teleCooldown;
    private Vector3 newPos;

	//Portal Audio
	public AudioClip portal;
	private AudioSource portalSource;


	// Use this for initialization
	void Start () {
		AudioSource[] allAudioSources = GetComponents<AudioSource>();
		portalSource = allAudioSources [4];
        canTele = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit)
    {
		if (hit.CompareTag ("Portal"))
        {
			if (canTele)
            {
                canTele = false;
                if(hit.gameObject.name == "PortalTL")
                {
                    newPos = possibleExits[3].transform.position;
                }
                if (hit.gameObject.name == "PortalTR")
                {
                    newPos = possibleExits[2].transform.position;
                }
                if (hit.gameObject.name == "PortalBL")
                {
                    newPos = possibleExits[1].transform.position;
                }
                if (hit.gameObject.name == "PortalBR")
                {
                    newPos = possibleExits[0].transform.position;
                }
                Debug.Log("teled");
                transform.position = newPos;
				//Full ship audio
				portalSource.clip = portal;
				portalSource.Play ();

				Invoke ("ResetTele", teleCooldown);
			}
		}
	}

    public void ResetTele()
    {
        canTele = true;
    }
}
