using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreController : MonoBehaviour {
    public int score = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        score = GetScore();
	}

    public int GetScore()
    {
        float z = gameObject.transform.position.z;
        float scoreMultiplicator = Mathf.Pow(2, Mathf.Floor(z / 1000));

        return Mathf.RoundToInt(scoreMultiplicator * z);
    }
}
