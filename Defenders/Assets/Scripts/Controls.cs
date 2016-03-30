using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour
{

    public Texture backgroundTexture;
    public Texture forgroundTexture;
    public Texture forgroundTexture2;

    public float controlsPlacementY;
    public float controlsPlacementX;

    public float logoPlacementY;
    public float logoPlacementX;

    public float guiPlacementY1;
    public float guiPlacementY2;
    
    public float guiPlacementX1;
    public float guiPlacementX2;
   

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        GUI.DrawTexture(new Rect(Screen.width * controlsPlacementX, Screen.height * controlsPlacementY, Screen.width - 600, Screen.height - 300), forgroundTexture);
        GUI.DrawTexture(new Rect(Screen.width * logoPlacementX, Screen.height * logoPlacementY, Screen.width - 800, Screen.height - 400), forgroundTexture2);

        if (GUI.Button(new Rect(Screen.width * guiPlacementX1, Screen.height * guiPlacementY1, Screen.width * .5F, Screen.height * .1F), "Start Game"))
        {
            print("Clicked Play Game");
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width * guiPlacementX2, Screen.height * guiPlacementY2, Screen.width * .5F, Screen.height * .1F), "Back"))
        {
            print("Clicked Back");
            Application.LoadLevel(0);
        }
       

    }
}