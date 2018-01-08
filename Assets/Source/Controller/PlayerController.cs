using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animation animations = null;
    public GameObject ground = null;
    public GameObject pause;
    public GameObject gameOverMenu;
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody rgb = null;
    private bool isCrashed = false;
    private bool isGrounded = true;
    private BoxCollider boxCol;
    private Vector3 lastPosition;
    private Boolean dieAnimationPlayed = false;

    // Sets everything in the controller up to start the game
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        SendMessage("SetLifes");
        gameOverMenu.SetActive(false);


       
        //pause = GameObject.Find("pausemenu");
        pause.SetActive(false);
<<<<<<< HEAD
        //gameOver = GameObject.Find("gameover");

=======
>>>>>>> 13e2b6760bccd49011fa899d95bebe86b903bb17
    }

    // Update is called once per frame
    // Checks if the player is touches the ground, which inputs are pressed and if the game is over and reacts to it
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

        if (!dieAnimationPlayed)
        {
            Move(Time.deltaTime);
        }
	}

    // allows the LifesController to tell the PlayerController that the player crashed
    public void playerCrashed()
    {
<<<<<<< HEAD
        isCrashed = true;
=======
        animations.Play("diehard"); 
>>>>>>> 13e2b6760bccd49011fa899d95bebe86b903bb17
    }

    // moves the player forward
    public void Move(float deltaTime)
    {
        gameObject.transform.Translate(new Vector3(0, 0, speed * deltaTime), Space.World);
    }

    // pauses the game
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    // plays the run animation and sets the hight of the player to full height
    public void Run()
    {
        animations.Play("run");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.399661, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.1984264, (float)0.01407976);
    }

    // plasy the Duck (salute) animation and sets the player height to the duck height to fit under obstacles
    public void Duck()
    {
        animations["salute"].speed = 10f;

        animations.Play("salute");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.09670291, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.09670291, (float)0.01407976);
    }

    // moves the player upwards and plays an animation
    public void Jump()
    {
        rgb.velocity = new Vector3(0, jumpHeight, 0);
        animations.Play("diehard");
    }

    // sets the isGrounded attribute to true if the player touches the ground
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // plays an animation and calls the OnObstacleTouched in LifesController if the player collided with an obstacle
    void OnTriggerEnter(Collider other)
    {
        lastPosition = new Vector3
        {
            x = gameObject.transform.position.x,
            y = gameObject.transform.position.y,
            z = gameObject.transform.position.x,
        };

        if (other.gameObject.CompareTag("Obstacle"))
        {
            animations.Play("diehard");
            Renderer groundRenderer = ground.GetComponent(typeof(Renderer)) as Renderer;
            groundRenderer.material.color = Color.blue;


            SendMessage("OnObstacleTouched");
            
        }
    }

    // sets the isGrounded to false if the player leaves the bottom
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

    // if the player died, this method once executes a die animation and shows a gameover menu
    public void Crashed()
    {
<<<<<<< HEAD
        if (!dieAnimationPlayed)
        {
            animations.Play("diehard");
            animations.Stop("run");
            rgb.velocity = new Vector3(0, 0, speed);
            dieAnimationPlayed = true;
            gameOverMenu.SetActive(true);
        }
       

=======
        animations.Play("diehard");
>>>>>>> 13e2b6760bccd49011fa899d95bebe86b903bb17
    }
}