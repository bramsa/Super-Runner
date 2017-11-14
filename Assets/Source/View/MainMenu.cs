using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Use this for initialization
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

    public void ShowHighscore()
    {
        // 3 = "highscore"
        SceneManager.LoadScene(3, LoadSceneMode.Single);
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
