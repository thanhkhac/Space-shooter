using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    Text scoreTextUI;

    private int Score;
    public int score
    {
        get { return this.Score; }
        set
        {
            this.Score = value;
            UpdateTextScoreUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    void UpdateTextScoreUI()
    {
        scoreTextUI.text = Score.ToString();
    }
}