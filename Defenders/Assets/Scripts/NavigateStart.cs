using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigateStart : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            Debug.Log("play");
            SceneManager.LoadScene("_Game");
        }
        /*if (Input.GetKeyDown("2"))
        {
            Debug.Log("Controls");
            SceneManager.LoadScene("Controls");
        }*/
        if (Input.GetKeyDown("3") || Input.GetKeyDown("escape"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
