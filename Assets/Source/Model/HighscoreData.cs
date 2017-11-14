using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Highscore", menuName = "Highscore", order = 1)]
public class HighscoreData : ScriptableObject {
    new public string name = null;
    public int score = 0;

    public bool IsHighestScore(int score)
    {
        return score > this.score;
    }

    public void SetHighscore(int score, string name)
    {
        if (IsHighestScore(score))
        {
            this.name = name;
            this.score = score;
        }
    }

    public string GetName()
    {
        return name;
    }

    public int GetScore()
    {
        return score;
    }
}
