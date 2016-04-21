using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {

    private TrailRenderer trailing;

	// Use this for initialization
	void Start () {
        trailing = GetComponent<TrailRenderer>();
        trailing.sortingLayerName = "notBack";
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
