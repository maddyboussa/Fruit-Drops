using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    /// Beings the game by loading the fgame scene irst level
    /// </summary>
    public void PlayGame()
    {
        // load the level with index 1 from the build queue
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Opens the controls sub-menu
    /// </summary>
    public void OpenControls()
    {
        Debug.Log("Controls open");

        // open controls here
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
    /// Quits the application
    /// Note: This will be ignored in the editor
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
