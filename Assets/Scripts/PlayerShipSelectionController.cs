// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;
using UnityEngine.UI;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ������ ���������� ������� � ���� ������ �������.
    /// </summary>
    public class PlayerShipSelectionController : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// ������ �� ������ �������.
        /// </summary>
        [SerializeField] private SpaceShip prefab;

        /// <summary>
        /// ������ �� ����� � ������ �������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI shipName;
        /// <summary>
        /// ������ �� ����� �� ��������� ������������� �������� �������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI hitpoints;
        /// <summary>
        /// ������ �� ����� �� ��������� ������������ �������� �������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI speed;
        /// <summary>
        /// ������ �� ����� �� ��������� ������������ �������� �������� �������.
        /// </summary>
        [SerializeField] private TextMeshProUGUI agility;

        /// <summary>
        /// ������ �� ��������� �������.
        /// </summary>
        [SerializeField] private Image preview;

        #endregion

        #region API



        #region Unity API

        /// <summary>
        /// ���������� �������� ��������� ������� � UI.
        /// </summary>
        private void Start()
        {
            if (prefab != null)
            {
                shipName.text = prefab?.Nickname;
                hitpoints.text = "�������� : " + prefab.HitPoints.ToString();
                speed.text = "�������� : " + prefab.MaxLinearVelocity.ToString();
                agility.text = "����������� : " + prefab.MaxAngularVelocity.ToString();
                preview.sprite = prefab?.PreviewImage;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// �������� �������.
        /// </summary>
        public void SelectShip()
        {
            LevelSequenceController.PlayerShip = prefab;

            MainMenuController.Instance.gameObject.SetActive(true);
        }

        #endregion

        #endregion
    }
}