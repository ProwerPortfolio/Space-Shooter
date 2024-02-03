// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Интерфейс энергии и патронов.
    /// </summary>
    public class UIEnegryAmmo : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// Ссылка на текст с энергией игрока.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uIEnergy;

        /// <summary>
        /// Ссылка на текст с патронами игрока.
        /// </summary>
        [SerializeField] private TextMeshProUGUI uIAmmo;

        /// <summary>
        /// Последнее обновлённое значение энергии.
        /// </summary>
        private int lastEnergy;

        /// <summary>
        /// Последнее обновлённое значение патронов.
        /// </summary>
        private int lastAmmo;

        #endregion

        #region API

        /// <summary>
        /// Обновляет интерфейс энергии и патронов.
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