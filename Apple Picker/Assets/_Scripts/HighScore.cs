using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;

    private Text txtCom;                //txtCom is a reference to this GO's text component

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        //if the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _SCORE = PlayerPrefs.GetInt("HighScore");
        }

        //assign the high score to Highscore
        PlayerPrefs.SetInt("HighScore", _SCORE);
    }
    
    static public int SCORE
    {
        get { return _SCORE; }

        private set
        {

            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);

            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= _SCORE) return;        //if scoreToTry is is not higher, bail
        SCORE = scoreToTry;
    }

    //the following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if( resetHighScoreNow )
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("High Score", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1000");
        }
    }
}
