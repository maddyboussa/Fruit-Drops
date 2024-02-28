using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region FIELDS

    // reference to score text
    [SerializeField] private TMP_Text scoreText;

    // reference to pause menu
    [SerializeField] private GameObject pauseMenu;
    private bool paused;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // deactivate pause menu on start
        pauseMenu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        // first check for game over -- skipping for now
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

    public void Resume()
    {
        // deactivate pause menu
        pauseMenu.SetActive(false);

        // unfreeze time
        Time.timeScale = 1.0f;

        paused = false;
    }


    public void OnScoreChanged(Component sender, object scoreData)
    {
        scoreText.text = scoreData.ToString();
    }
}
