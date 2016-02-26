using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    //How fast are we
    public float speed;
    //Where are we facing?

    private Transform child;
	void Start () {
        child = transform.GetChild(0);
	}
	
	void FixedUpdate () {
        move();
    }

    void move()
    {
        float up = Input.GetAxis("Vertical");                                           //Get the vertical axis set in Unity editor
        float side = Input.GetAxis("Horizontal");                                       //Get the vertical axis set in Unity editor

        Vector3 moving = new Vector3(side, up, 0f);                                     //set up V3 based on inputs
        float angle = Mathf.Atan2(side, up) * Mathf.Rad2Deg;                            //create a float, set equal to the Atan2 of side and up

        if (moving != Vector3.zero) {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            child.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }

        transform.Translate(moving * speed * Time.deltaTime,Space.World);
    }
}
