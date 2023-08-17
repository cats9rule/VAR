using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
        public enum Score
        {
                AiScore,PlayerScore
        }

        public TMP_Text AiScoreText, PlayerScoreText;
        private int aiScore, playerScore;

        public void Increment(Score whichScore)
        {
                if (whichScore == Score.AiScore)
                        AiScoreText.text = (++aiScore).ToString();
                else
                        PlayerScoreText.text = (++playerScore).ToString();
        }

        public void ResetScore()
        {
                aiScore = playerScore = 0;
                AiScoreText.text = PlayerScoreText.text = "0";
        }
}
