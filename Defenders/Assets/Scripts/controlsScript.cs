using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class controlsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1") || Input.GetKeyDown("2"))
        {
            Debug.Log("Play");
            SceneManager.LoadScene("_Game");
        }

        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
	}
}
