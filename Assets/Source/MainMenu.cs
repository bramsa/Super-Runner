using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey("escape"))
                Application.Quit();
    }
}
