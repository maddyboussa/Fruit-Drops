using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    #region FIELDS
    private float gameScore;

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// updates the game score based on any changes in score from other game objects
    /// </summary>
    public void OnScoreChanged(Component sender, object scoreData)
    {
        // store the incoming score as the "game" score
        gameScore = (float)scoreData;
    }


    // this script will handle the "win" conditions, saving high scores, etc.
    // it will need a reference to the current score??
}
