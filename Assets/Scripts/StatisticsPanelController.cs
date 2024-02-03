// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ���������� ����������.
    /// </summary>
    public class StatisticsPanelController : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// ������ �� ����� � ����� ��������� ������� ������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI kills;

        /// <summary>
        /// ������ �� ����� � ����� ��������� ����� ������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI score;

        /// <summary>
        /// ������ �� ����� � ����� ��������� ���������� �������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI time;

        #endregion

        #region API



        #region Unity API

        /// <summary>
        /// �������� ������ � ��������� ��������� ����������.
        /// </summary>
        private void OnEnable()
        {
            GlobalPlayerStatistics.Instance.GlobalKills = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalKills", 0);
            GlobalPlayerStatistics.Instance.GlobalScore = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalScore", 0);
            GlobalPlayerStatistics.Instance.GlobalTime = PlayerPrefs.GetInt("GlobalPlayerStatistics:globalTime", 0);

            kills.text = "��������: " + GlobalPlayerStatistics.Instance.GlobalKills.ToString();
            score.text = "����: " + GlobalPlayerStatistics.Instance.GlobalScore.ToString();
            time.text = "�����: " + GlobalPlayerStatistics.Instance.GlobalTime.ToString();
        }

        #endregion

        #region Public API



        #endregion

        #endregion
    }
}