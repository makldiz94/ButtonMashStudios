﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed;
    private GameObject bulletHolder;

    void Awake()
    {
        bulletHolder = GameObject.FindGameObjectWithTag("BulletHold");
    }

	// Use this for initialization
	void Start () {
        transform.parent = bulletHolder.transform;
        Destroy(gameObject, 3f);
	}

    void Update () {
        Vector3 move = transform.up;
        move *= Time.deltaTime * speed;
        transform.Translate(move, Space.World);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
