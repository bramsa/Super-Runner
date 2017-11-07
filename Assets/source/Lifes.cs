using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
	
	public int lifes;
	// Use this for initialization
	void Start () {
		lifes = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
			
	}

	void OnObstacleTouched() {
		lifes--;

		if(lifes == 0) {
			// gameover-Methode aufrufen
			gameover();
		}
	}
}