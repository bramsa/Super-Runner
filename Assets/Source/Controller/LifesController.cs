
using UnityEngine;

public class LifesController : MonoBehaviour {
	
	public int lifes;

	// bei Spielstart aufrufen um die Leben auf 2 zu setzen
	void SetLifes ()
    {
		lifes = 2;
	}

	void OnObstacleTouched()
    {
		// minus 1 leben bei Hindernisberührung
		lifes--;

		// wenn keine Leben mehr: gameover-Methode aufrufen
		if (lifes == 0)
        {
            GameOver();            
		}
	}

    void GameOver()
    {
        Destroy(gameObject);
    }
}