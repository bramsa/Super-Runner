using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// The class for the main menu / starting screen..
/// </summary>
public class MainMenu : MonoBehaviour {

    public Text txtHighscore = null;
    public HighscoreData highScoreData = null;

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    void Start()
    {
        // do nothing
	}

    /// <summary>
    /// Starts the game with the corresponding scene
    /// </summary>
    public void StartGame()
    {
        // 1 = "game"
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    /// <summary>
    /// Shows the highscore on the main menu.
    /// </summary>
    public void OnShowHighscore()
    {       
        if (txtHighscore != null)
        {
            txtHighscore.text = highScoreData.GetScore().ToString();
        }
    }

    /// <summary>
    /// Shuts the whole application down.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKey("escape"))
                Application.Quit();
    }
}
