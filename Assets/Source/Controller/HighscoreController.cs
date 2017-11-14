﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

    public Text LBLScoreOutput = null;
    public HighscoreData highScoreData = null;

    private int score = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        score = GetScore();
        if (LBLScoreOutput != null)
        {
            LBLScoreOutput.text = score.ToString();
        }
    }

    public int GetScore()
    {
        float z = gameObject.transform.position.z;
        float scoreMultiplicator = Mathf.Pow(2, Mathf.Floor(z / 1000));

        return Mathf.RoundToInt(scoreMultiplicator * z);
    }

    void OnDestroy()
    {
        if (highScoreData.IsHighestScore(score))
        {
            highScoreData.SetHighscore(score, "Playername");
        }
    }
}
