using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Animation animations = null;
    public GameObject ground = null;
    public GameObject pause = null;
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody rgb = null;
    
    private bool isGrounded = true;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
        SendMessage("SetLifes");
        pause = GameObject.Find("pausemenu");
        pause.SetActive(false);
       
    }
	
	// Update is called once per frame
	void Update () {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            rgb.velocity = new Vector3(0, jumpHeight, 0);
            animations.Play("diehard");

        } else if (isGrounded && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow)))  {

            animations.Play("salute");
        } else  {
             animations.Play("run");
        }

        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }

        gameObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.Equals(ground))
        {
            isGrounded = true;
        }

        if (col.gameObject.CompareTag("Obstacle"))
        {
           // SendMessage("OnObstacleTouched");
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.Equals(ground))
        {
            isGrounded = false;
        }
    }

    public void OnResume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnNewGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
