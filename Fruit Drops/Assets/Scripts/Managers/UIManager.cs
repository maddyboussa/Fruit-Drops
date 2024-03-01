using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region FIELDS

    // reference to score text
    [SerializeField] private TMP_Text scoreText;

    // reference to pause menu
    [SerializeField] private GameObject pauseMenu;
    private bool paused;

    private bool gameOver;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // deactivate pause menu on start and set default values
        pauseMenu.SetActive(false);
        paused = false;
        gameOver = false;

        // ensure time isn't frozen
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Toggles the paused state of the game on and off
    /// </summary>
    public void Pause()
    {
        // first ensure game has not already ended
        if (!gameOver)
        {
            // if game is not over, verify game is not already paused
            if (paused)
            {
                // if so, resume game
                Resume();
            }
            else
            {
                // if unpaused, pause the game and activate the pause menu
                // activate pause menu canvas
                pauseMenu.SetActive(true);

                // make sure cursor is visible
                //Cursor.visible = true;

                // freeze time
                Time.timeScale = 0.0f;

                paused = true;
            }
        }
    }

    /// <summary>
    /// Resumes the game
    /// </summary>
    private void Resume()
    {
        // deactivate pause menu
        pauseMenu.SetActive(false);

        // unfreeze time
        Time.timeScale = 1.0f;

        paused = false;
    }

    /// <summary>
    /// Loads main menu scene
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads game scene
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Opens the options sub-menu
    /// </summary>
    public void OpenOptions()
    {
        Debug.Log("Options open");

        // open options here
    }


    /// <summary>
    /// Listens for a change in score from other scripts, and updates score UI accordingly
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="scoreData"></param>
    public void OnScoreChanged(Component sender, object scoreData)
    {
        scoreText.text = scoreData.ToString();
    }

    /// <summary>
    /// Listens for a change in the status of game over conditions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="scoreData"></param>
    public void OnGameOver(Component sender, object scoreData)
    {
        // update this script's knowledge of game over status
        gameOver = true;
    }
}
