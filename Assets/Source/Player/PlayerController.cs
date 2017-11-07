﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject ground = null;
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody rgb = null;
    
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            rgb.velocity = new Vector3(0, jumpHeight, 0);
        }

        gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.Equals(ground))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.Equals(ground))
        {
            isGrounded = false;
        }
    }
}
