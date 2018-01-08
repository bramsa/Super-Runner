using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The controller for the behaviour of the player.
/// </summary>
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
    private int isGrounded = 0;
    private BoxCollider boxCol;
    private Vector3 lastPosition;
    private Boolean dieAnimationPlayed = false;

    /// <summary>
    ///  Sets everything in the controller up to start the game
    /// </summary>
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        SendMessage("SetLifes");
        // gameOverMenu.SetActive(false);

        //pause = GameObject.Find("pausemenu");
        pause.SetActive(false);
        //gameOver = GameObject.Find("gameover");
    }

    /// <summary>
    /// Update is called once per frame
    /// Checks if the player is touches the ground, which inputs are pressed and if the game is over and reacts to it.
    /// </summary>
    void Update()
    {
        if (isCrashed)
        {
            Crashed();
        }
        else if (isGrounded > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            Jump();
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow)))
        {
            Duck();
        }
        else if (isGrounded > 0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
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

    /// <summary>
    ///  Allows the LifesController to tell the PlayerController that the player crashed
    /// </summary>
    public void playerCrashed()
    {
        isCrashed = true;


    }

    /// <summary>
    ///  Moves the player forward
    /// </summary>
    /// <param name="deltaTime"></param>
    public void Move(float deltaTime)
    {
        gameObject.transform.Translate(new Vector3(0, 0, speed * deltaTime), Space.World);
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }

    /// <summary>
    /// Plays the run animation and sets the hight of the player to full height.
    /// </summary>
    public void Run()
    {
        animations.Play("run");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.399661, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.1984264, (float)0.01407976);
    }

    /// <summary>
    /// Plays the Duck (salute) animation and sets the player height to the duck height to fit under obstacles.
    /// </summary>
    public void Duck()
    {
        animations["salute"].speed = 10f;

        animations.Play("salute");
        boxCol = gameObject.GetComponent<BoxCollider>();

        boxCol.size = new Vector3((float)0.1685139, (float)0.09670291, (float)0.2071988);
        boxCol.center = new Vector3((float)-8.940697e-09, (float)0.09670291, (float)0.01407976);
    }

    /// <summary>
    ///  Moves the player upwards and plays an animation
    /// </summary>
    public void Jump()
    {
        rgb.velocity = new Vector3(0, jumpHeight, 0);
        animations.Play("diehard");
    }

    /// <summary>
    /// Sets the isGrounded attribute to true if the player touches the ground
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded++;
        }
    }

    /// <summary>
    /// Plays an animation and calls the OnObstacleTouched in LifesController if the player collided with an obstacle
    /// </summary>
    /// <param name="other"></param>
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
           /* Renderer groundRenderer = ground.GetComponent(typeof(Renderer)) as Renderer;
            groundRenderer.material.color = Color.blue;*/


            SendMessage("OnObstacleTouched");

        }
    }

    /// <summary>
    /// Sets the isGrounded to false if the player leaves the bottom
    /// </summary>
    /// <param name="col"></param>
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded--;
        }

    }

    /// <summary>
    /// Close the pause menu.
    /// </summary>
    public void OnResume()
    {
        GameObject.Find("pausemenu").SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// Start the game over.
    /// </summary>
    public void OnNewGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    /// <summary>
    /// If the player died, this method once executes a die animation and shows a gameover menu
    /// </summary>
    public void Crashed()
    {
        if (!dieAnimationPlayed)
        {
            animations.Play("diehard");
            animations.Stop("run");
            rgb.velocity = new Vector3(0, 0, speed);
            dieAnimationPlayed = true;
            // gameOverMenu.SetActive(true);
        }


    }
}
