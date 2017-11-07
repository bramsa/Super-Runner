using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {
	
	public int lifes;

	// bei Spielstart aufrufen um die Leben auf zwei zu setzen
	void SetLifes () {
		lifes = 2;
	}

	void OnObstacleTouched() {
		lifes--;

		if(lifes == 0) {
			// gameover-Methode aufrufen
			//gameover();
		}
	}
}