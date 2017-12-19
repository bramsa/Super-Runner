using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is responsible for the handling of the high score.
/// </summary>
public class HighscoreController : MonoBehaviour
{

    public Text LBLScoreOutput = null;
    public HighscoreData highScoreData = null;
    public Text txtHighscore = null;

    private int score = 0;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        score = GetScore();
        if (LBLScoreOutput != null)
        {
            LBLScoreOutput.text = score.ToString();
        }
    }

    /// <summary>
    /// Calculates the actual score by the position of the object owner (game object)
    /// </summary>
    /// <returns>the score</returns>
    public int GetScore()
    {
        float z = gameObject.transform.position.z;
        float scoreMultiplicator = Mathf.Pow(2, Mathf.Floor(z / 1000));

        return Mathf.RoundToInt(scoreMultiplicator * z);
    }

    /// <summary>
    /// This function should be called when the player dies
    /// </summary>
    public void OnPlayerDies()
    {
        PlayerController playerController = gameObject.GetComponent(typeof(PlayerController)) as PlayerController;
        playerController.playerCrashed();
        if (highScoreData.IsHighestScore(score))
        {
            highScoreData.SetHighscore(score, "Playername");
        }
    }

    /// <summary>
    /// This function should be called, if the highscore has to be displayed in the txtHighscore
    /// </summary>
    public void OnShowHighscore()
    {
        if (txtHighscore != null)
        {
            txtHighscore.text = highScoreData.GetScore().ToString();
        }
    }
}
