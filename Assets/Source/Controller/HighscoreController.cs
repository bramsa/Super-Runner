using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour
{

    public Text LBLScoreOutput = null;
    public HighscoreData highScoreData = null;

    private int score = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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

    public Text txtHighscore = null;
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
