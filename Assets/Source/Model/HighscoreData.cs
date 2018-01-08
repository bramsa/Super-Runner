using UnityEngine;

/// <summary>
/// The model class which is responsible for the highscore.
/// </summary>
[CreateAssetMenu(fileName = "Highscore", menuName = "Highscore", order = 1)]
public class HighscoreData : ScriptableObject {
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
    public void SetHighscore(int score)
    {
        if (IsHighestScore(score))
        {
            this.score = score;
        }
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
