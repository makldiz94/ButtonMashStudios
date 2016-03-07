using UnityEngine;
using System.Collections;

public class HumanColorize : MonoBehaviour {

    public string col;

    private string[] possibleColors = { "red", "blue", "yellow", "black"};

	void Start () {
        int rand = Random.Range(0, 4);
        col = possibleColors[rand];
        Color curColor = GetComponent<SpriteRenderer>().color;
        switch (col)
        {
            case "red":
                curColor = Color.red;
                break;
            case "blue":
                curColor = Color.blue;
                break;
            case "yellow":
                curColor = Color.yellow;
                break;
            case "black":
                curColor = Color.black;
                break;
        }
        GetComponent<SpriteRenderer>().color = curColor;
	}
}
