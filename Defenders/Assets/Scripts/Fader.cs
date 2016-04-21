﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour
{

    public static Fader s;
    public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.

    public bool sceneEnding = false;
    private bool sceneStarting = true;      // Whether or not the scene is still fading in.


    void Awake()
    {
        // Set the texture so that it is the the size of the screen and covers it.
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height * 2);
    }

    void Start()
    {
        if(s == null)
        {
            s = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        // If the scene is starting...
        if (sceneStarting)
            // ... call the StartScene function.
            StartScene();

        if (sceneEnding)
        {
            EndScene();
        }
    }


    void FadeToClear()
    {
        // Lerp the colour of the texture between itself and transparent.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.clear, fadeSpeed * Time.deltaTime);
    }


    void FadeToBlack()
    {
        Debug.Log("work");
        // Lerp the colour of the texture between itself and black.
        GetComponent<GUITexture>().color = Color.Lerp(GetComponent<GUITexture>().color, Color.black, fadeSpeed * Time.deltaTime);
        Debug.Log("works");

    }


    public void StartScene()
    {
        // Fade the texture to clear.
        FadeToClear();

        // If the texture is almost clear...
        if (GetComponent<GUITexture>().color.a <= 0.05f)
        {
            // ... set the colour to clear and disable the GUITexture.
            GetComponent<GUITexture>().color = Color.clear;
            GetComponent<GUITexture>().enabled = false;

            // The scene is no longer starting.
            sceneStarting = false;
        }
    }

    public void SetBool()
    {
        sceneEnding = true;
    }

    public void EndScene()
    {
        GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height * 2);
        Debug.Log("Ending");
        // Make sure the texture is enabled.
        GetComponent<GUITexture>().enabled = true;

        // Start fading towards black.
        FadeToBlack();       
    }
}