// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using TMPro;
using UnityEngine.UI;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер панели отдельного корабля в окне выбора корабля.
    /// </summary>
    public class PlayerShipSelectionController : MonoBehaviour
    {
        #region Parameters

        /// <summary>
        /// Ссылка на префаб корабля.
        /// </summary>
        [SerializeField] private SpaceShip prefab;

        /// <summary>
        /// Ссылка на текст с именем корабля.
        /// </summary>
        [SerializeField] private TextMeshProUGUI shipName;
        /// <summary>
        /// Ссылка на текст со значением максимального здоровья корабля.
        /// </summary>
        [SerializeField] private TextMeshProUGUI hitpoints;
        /// <summary>
        /// Ссылка на текст со значением максимальной скорости корабля.
        /// </summary>
        [SerializeField] private TextMeshProUGUI speed;
        /// <summary>
        /// Ссылка на текст со значением максимальной скорости поворота корабля.
        /// </summary>
        [SerializeField] private TextMeshProUGUI agility;

        /// <summary>
        /// Ссылка на привьюшку корабля.
        /// </summary>
        [SerializeField] private Image preview;

        #endregion

        #region API



        #region Unity API

        /// <summary>
        /// Подцепляет основные параметры корабля в UI.
        /// </summary>
        private void Start()
        {
            if (prefab != null)
            {
                shipName.text = prefab?.Nickname;
                hitpoints.text = "Здоровье : " + prefab.HitPoints.ToString();
                speed.text = "Скорость : " + prefab.MaxLinearVelocity.ToString();
                agility.text = "Мобильность : " + prefab.MaxAngularVelocity.ToString();
                preview.sprite = prefab?.PreviewImage;
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Выбирает корабль.
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