// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер окна главного меню.
    /// </summary>
    public class MainMenuController : MonoSingleton<MainMenuController>
    {
        #region Parameters

        /// <summary>
        /// Корабль, выбираемый по умолчанию.
        /// </summary>
        [SerializeField] private SpaceShip defaultPlayerShip;

        /// <summary>
        /// Ссылка на меню выбора эпизодов.
        /// </summary>
        [SerializeField] private GameObject episodeSelection;

        /// <summary>
        /// Ссылка на меню выбора корабля.
        /// </summary>
        [SerializeField] private GameObject shipSelection;

        #endregion

        #region API



        #region Unity API

        private void Start()
        {
            LevelSequenceController.PlayerShip = defaultPlayerShip;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Выполняется при нажатии на кнопку "Новая игра".
        /// </summary>
        public void OnButtonStartNew()
        {
            episodeSelection.SetActive(true);

            gameObject.SetActive(false);
        }

        /// <summary>
        /// Выполняется при нажатии на кнопку "Выход".
        /// </summary>
        public void OnButtonExit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Выполняется при нажатии на кнопку "Выбор корабля".
        /// </summary>
        public void OnButtonSelectShip()
        {
            shipSelection.SetActive(true);

            gameObject.SetActive(false);
        }

        #endregion

        #endregion
    }
}