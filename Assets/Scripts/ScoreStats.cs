// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    public class ScoreStats : MonoBehaviour
    {
        #region Parameters

        [SerializeField] private TextMeshProUGUI text;

        private int lastScore;

        #endregion

        #region API

        private void UpdateScore()
        {
            if (Player.Instance != null)
            {
                int currentScore = Player.Instance.Score;

                if (lastScore != currentScore)
                {
                    lastScore = currentScore;

                    text.text = lastScore.ToString();
                }
            }
        }

        #region Unity API

        private void Update()
        {
            UpdateScore();
        }

        #endregion

        #region Public API



        #endregion

        #endregion
    }
}