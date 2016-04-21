using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

    public int score;

	void Awake()
    {

    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


}
