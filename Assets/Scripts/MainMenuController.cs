// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ���� �������� ����.
    /// </summary>
    public class MainMenuController : MonoSingleton<MainMenuController>
    {
        #region Parameters

        /// <summary>
        /// �������, ���������� �� ���������.
        /// </summary>
        [SerializeField] private SpaceShip defaultPlayerShip;

        /// <summary>
        /// ������ �� ���� ������ ��������.
        /// </summary>
        [SerializeField] private GameObject episodeSelection;

        /// <summary>
        /// ������ �� ���� ������ �������.
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
        /// ����������� ��� ������� �� ������ "����� ����".
        /// </summary>
        public void OnButtonStartNew()
        {
            episodeSelection.SetActive(true);

            gameObject.SetActive(false);
        }

        /// <summary>
        /// ����������� ��� ������� �� ������ "�����".
        /// </summary>
        public void OnButtonExit()
        {
            Application.Quit();
        }

        /// <summary>
        /// ����������� ��� ������� �� ������ "����� �������".
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