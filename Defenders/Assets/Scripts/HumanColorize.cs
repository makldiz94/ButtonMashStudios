using UnityEngine;
using System.Collections;

public class HumanColorize : MonoBehaviour {

    public string col;

    //red = lava, blue = ice, yellow = egg, green = gas, white = saturn 
    private string[] possibleColors = { "red", "blue", "yellow", "green", "brown"};

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
            case "brown":
                Color colo = Color.white;
                colo.r = 146f;
                colo.g = 102f;
                colo.b = 0f;
                curColor = colo;
                break;
        }
        GetComponent<SpriteRenderer>().color = curColor;
	}
}
