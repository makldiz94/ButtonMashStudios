using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        move();
    }

    void move()
    {
        float up = Input.GetAxis("Vertical");                                           //Get the vertical axis set in Unity editor
        float side = Input.GetAxis("Horizontal");                                       //Get the vertical axis set in Unity editor

        Vector3 moving = new Vector3(side, up, 0f);                                     //set up V3 based on inputs
        float angle = Mathf.Atan2(side, up) * Mathf.Rad2Deg;                            //create a float, set equal to the Atan2 of side and up

        if (side != 0 || up != 0)                                                        //stops it from resetting if x or y are zero
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);             //change the objects rotation based on a Quaternion
                                                                                        //using our angle and a vector3                                                                  //if our bool in editor is true, move this way
        transform.Translate(moving * speed * Time.deltaTime, Space.World);
    }
}
