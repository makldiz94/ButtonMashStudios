using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    public Texture backgroundTexture;
  
    public Texture forgroundTexture;

  

    public float logoPlacementY;
    public float logoPlacementX;

    public float guiPlacementY1;
    public float guiPlacementY2;

    public float guiPlacementX1;
    public float guiPlacementX2;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
       
        GUI.DrawTexture(new Rect(Screen.width * logoPlacementX, Screen.height * logoPlacementY, Screen.width - 800, Screen.height - 400), forgroundTexture);

        if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5F, Screen.height * .1F), "Play Again!!"))
        {
            print("Clicked Play Again");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5F, Screen.height * .1F), "Quit Game"))
        {
            print("Clicked Quit Game");
            Application.Quit();
        }


    }
}