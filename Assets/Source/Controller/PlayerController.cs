using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animation animations = null;
    public GameObject ground = null;
    public float speed = 10f;
    public float jumpHeight = 10f;

    private Rigidbody rgb = null;
    private bool isCrashed = false;
    private bool isGrounded = true;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
        //SendMessage("SetLifes");
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)))
        {
            rgb.velocity = new Vector3(0, jumpHeight, 0);
            animations.Play("diehard");

        } else if (isGrounded && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKey(KeyCode.DownArrow)))  {

            animations["salute"].speed = 10f;

            animations.Play("salute");
        }
        else if (!isGrounded) {
            animations.Play("diehard");
        } else if (isCrashed)
        {
            animations.Play("diehard");
        } else  {
             animations.Play("run");
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
            animations.Play("diehard");
            isCrashed = true;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.Equals(ground))
        {
            isGrounded = false;
        }
    }
}
