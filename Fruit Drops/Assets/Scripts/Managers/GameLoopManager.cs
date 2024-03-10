using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    #region FIELDS
    private float gameScore;
    [SerializeField] private GameEvent onGameOver;

    [SerializeField] private int numInDangerToLose = 4;
    private int numInDanger;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        numInDanger = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if there are 4 or more fruit in danger zone, game is over
        if (numInDanger >= numInDangerToLose)
        {
            // raise game over event to telegraph ending to UI manager
            onGameOver.Raise(this, gameScore);
        }
    }

    /// <summary>
    /// Updates the game score based on any changes in score from other game objects
    /// </summary>
    public void OnScoreChanged(Component sender, object scoreData)
    {
        // store the incoming score as the "game" score
        gameScore = (float)scoreData;
    }

    /// <summary>
    /// Increments number of fruit currently in danger zone
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="other"></param>
    public void OnAddDangerCollision(Component sender, object other)
    {
        numInDanger++;
    }

    /// <summary>
    /// Decrements number of fruit currently in danger zone
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="other"></param>
    public void OnRemoveDangerCollision(Component sender, object other)
    {
        numInDanger--;
    }


    // this script will handle the "win" conditions, saving high scores, etc.
    // it will need a reference to the current score??

    // when game is over raise onGameOver.Raise(...) event
}
