using UnityEngine;
using System.Collections;

public class HumanColorize : MonoBehaviour {

    public string col;

    //red = lava, blue = ice, yellow = egg, green = gas, white = saturn 
    private string[] possibleColors = { "red", "blue", "yellow", "green", "white"};

	void Start () {
        int rand = Random.Range(0, 5);
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
            case "green":
                curColor = Color.green;
                break;
            case "white":
                curColor = Color.white;
                break;
        }
        GetComponent<SpriteRenderer>().color = curColor;
	}
}
