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
		// minus 1 leben bei Hinernisberührung
		lifes--;

		// wenn keine Leben mehr: gameover-Methode aufrufen
		if(lifes == 0) {			
			//GameOver();
		}
	}
}