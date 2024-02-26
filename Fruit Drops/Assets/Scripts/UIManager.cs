using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    #region FIELDS

    // reference to score text
    [SerializeField] private TMP_Text scoreText;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScoreChanged(Component sender, object scoreData)
    {
        Debug.Log(scoreText);
        scoreText.text = scoreData.ToString();
    }
}
