// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ��������� ������� � ��������.
    /// </summary>
    public class UIEnegryAmmo : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// ������ �� ����� � �������� ������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uIEnergy;

        /// <summary>
        /// ������ �� ����� � ��������� ������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uIAmmo;

        /// <summary>
        /// ��������� ���������� �������� �������.
        /// </summary>
        private int lastEnergy;

        /// <summary>
        /// ��������� ���������� �������� ��������.
        /// </summary>
        private int lastAmmo;

        #endregion

        #region API

        /// <summary>
        /// ��������� ��������� ������� � ��������.
        /// </summary>
        private void UpdateHealth()
        {
            if (Player.Instance != null)
            {
                int currentEnergy = (int)Player.Instance.ActiveShip.PrimaryEnergy;

                if (lastEnergy != currentEnergy)
                {
                    lastEnergy = currentEnergy;

                    uIEnergy.text = lastEnergy.ToString();
                }

                int currentAmmo = Player.Instance.ActiveShip.SecondaryAmmo;

                if (lastAmmo != currentAmmo)
                {
                    lastAmmo = currentAmmo;

                    uIAmmo.text = lastAmmo.ToString();
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