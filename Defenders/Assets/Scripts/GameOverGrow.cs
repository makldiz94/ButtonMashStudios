using UnityEngine;
using System.Collections;

public class GameOverGrow : MonoBehaviour {

    public float size;
    public float max = 1.1f;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (this.transform.localScale.x < max)
        {
            this.transform.localScale += new Vector3(size, size, size);

        }
    }
}
