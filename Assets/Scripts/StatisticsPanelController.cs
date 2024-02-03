// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер глобальной статистики.
    /// </summary>
    public class StatisticsPanelController : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// Ссылка на текст с общим значением убийств игрока.
        /// </summary>
        [SerializeField] private TextMeshProUGUI kills;

        /// <summary>
        /// Ссылка на текст с общим значением очков игрока.
        /// </summary>
        [SerializeField] private TextMeshProUGUI score;

        /// <summary>
        /// Ссылка на текст с общим значением прошедшего времени.
        /// </summary>
        [SerializeField] private TextMeshProUGUI time;

        #endregion

        #region API



        #region Unity API

        /// <summary>
        /// Получает данные и обновляет интерфейс статистики.
        /// </summary>
        private void OnEnable()
        {
            GlobalPlayerStatistics.Instance.GlobalKills = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalKills", 0);
            GlobalPlayerStatistics.Instance.GlobalScore = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalScore", 0);
            GlobalPlayerStatistics.Instance.GlobalTime = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalTime", 0);

            kills.text = "Убийства: " + GlobalPlayerStatistics.Instance.GlobalKills.ToString();
            score.text = "Очки: " + GlobalPlayerStatistics.Instance.GlobalScore.ToString();
            time.text = "Время: " + GlobalPlayerStatistics.Instance.GlobalTime.ToString();
        }

        #endregion

        #region Public API



        #endregion

        #endregion
    }
}