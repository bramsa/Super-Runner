using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The model class which is responsible for the highscore.
/// </summary>
[CreateAssetMenu(fileName = "Highscore", menuName = "Highscore", order = 1)]
public class HighscoreData : ScriptableObject {
    new public string name = null;
    public int score = 0;

    /// <summary>
    /// Check if the score is the highscore.
    /// </summary>
    /// <param name="score"></param>
    /// <returns></returns>
    public bool IsHighestScore(int score)
    {
        return score > this.score;
    }

    /// <summary>
    /// Set the highscore, if it is the highscore.
    /// </summary>
    /// <param name="score"></param>
    /// <param name="name"></param>
    public void SetHighscore(int score, string name)
    {
        if (IsHighestScore(score))
        {
            this.name = name;
            this.score = score;
        }
    }

    /// <summary>
    /// Returns the name.
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return name;
    }

    /// <summary>
    /// Returns the score.
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return score;
    }
}
