using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("GrabScore", .05f);
	}
	
	void GrabScore()
    {
        Debug.Log(GameObject.Find("Score").GetComponent<Scoring>().score);
        this.gameObject.GetComponent<Text>().text = GameObject.Find("Score").GetComponent<Scoring>().score.ToString();
        Destroy(GameObject.Find("Score"));
    }
}
