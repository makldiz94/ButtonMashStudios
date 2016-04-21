using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavigateGO : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("3"))
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Replay");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
