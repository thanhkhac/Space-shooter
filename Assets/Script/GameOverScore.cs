using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Script
{
    public class GameOverScore : MonoBehaviour
    {
        public GameScore gameScore; 
        public Text scoreTextUI; 

        void Start()
        {
            if (gameScore == null)
            {
                gameScore = FindObjectOfType<GameScore>(); 
            }
            UpdateScoreUI();
        }

        void Update()
        {
            UpdateScoreUI();
        }

        void UpdateScoreUI()
        {
            if (gameScore != null)
            {
                scoreTextUI.text = gameScore.score.ToString();
            }
        }
    }
}