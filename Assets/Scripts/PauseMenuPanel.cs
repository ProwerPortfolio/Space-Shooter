// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ���� �����.
    /// </summary>
    public class PauseMenuPanel : MonoBehaviour
    {
        #region Parameters



        #endregion

        #region API



        #region Unity API

        private void Start()
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Public API

        /// <summary>
        /// ��������� ����� �� ������� ������.
        /// </summary>
        public void OnButtonShowPause()
        {
            Time.timeScale = 0;

            gameObject.SetActive(true);
        }

        /// <summary>
        /// ����������� ����� � ����������� ���� �� ������� ������.
        /// </summary>
        public void OnButtonContinue()
        {
            Time.timeScale = 1;

            gameObject.SetActive(false);
        }

        /// <summary>
        /// ����������� ����� � ����� � ������� ���� �� ������� ������.
        /// </summary>
        public void OnButtonMainMenu()
        {
            Time.timeScale = 1;

            gameObject.SetActive(false);

            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);
        }

        #endregion

        #endregion
    }
}