﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Animation animations = null;
    public GameObject ground = null;
    public GameObject pause = null;
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody rgb = null;
    private bool isCrashed = false;
    private bool isGrounded = true;
    private BoxCollider boxCol;

    // Use this for initialization
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        SendMessage("SetLifes");
        pause = GameObject.Find("pausemenu");
        pause.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isCrashed)
        {
            Crashed();
        }
        else if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            Jump();
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow)))
        {

            Duck();
        }
        else if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            rgb.velocity = new Vector3(0, jumpHeight, 0);
            animations.Play("diehard");

        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow)))
        {

            animations["salute"].speed = 10f;

            animations.Play("salute");
            boxCol = gameObject.GetComponent<BoxCollider>();

            boxCol.size = new Vector3((float)0.1685139, (float)0.09670291, (float)0.2071988);
            boxCol.center = new Vector3((float)-8.940697e-09, (float)0.09670291, (float)0.01407976);
        }
        else
        {
            animations.Play("run");
            boxCol = gameObject.GetComponent<BoxCollider>();

            Run();
        }

        if (Input.GetKeyDown("escape"))
        {
            Pause();
           
        }

        Move(Time.deltaTime);
	}

    public void Die()
    {
        animations.Play("diehard"); 
    
    }

    public void Move(float deltaTime)
    {
        gameObject.transform.Translate(new Vector3(0, 0, speed * deltaTime), Space.World);
    }

    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    public void Run()
    {

        animations.Play("run");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.399661, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.1984264, (float)0.01407976);
    }

    public void Duck()
    {
        animations["salute"].speed = 10f;

        animations.Play("salute");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.09670291, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.09670291, (float)0.01407976);
    }

    public void Jump()
    {
        rgb.velocity = new Vector3(0, jumpHeight, 0);
        animations.Play("diehard");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SendMessage("OnObstacleTouched");
            animations.Play("diehard");
            isCrashed = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void OnResume()
    {
        GameObject.Find("pausemenu").SetActive(false);
        Time.timeScale = 1;
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Crashed()
    {
        animations.Play("diehard");

    }
}
