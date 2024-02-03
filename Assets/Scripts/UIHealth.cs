// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ��������� ��������.
    /// </summary>
    public class UIHealth : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// ������ �� ����� �� ��������� ������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uIHealth;

        /// <summary>
        /// ��������� ���������� �������� ��������.
        /// </summary>
        private int lastHP;

        #endregion

        #region API

        /// <summary>
        /// ��������� ��������� ��������.
        /// </summary>
        private void UpdateHealth()
        {
            if (Player.Instance != null)
            {
                int currentHP = Player.Instance.ActiveShip.CurrentHitPoints;

                if (lastHP != currentHP)
                {
                    lastHP = currentHP;

                    uIHealth.text = lastHP.ToString();
                }
            }
        }

        #region Unity API

        private void Update()
        {
            UpdateHealth();
        }

        #endregion

        #region Public API



        #endregion

        #endregion
    }
}