// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Условие завершения уровня по достижению позиции.
    /// </summary>
    [RequireComponent(typeof(CircleCollider2D))]
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        #region Parameters

        /// <summary>
        /// Достигнута ли необходимая позиция?
        /// </summary>
        private bool achieved;

        /// <summary>
        /// Вошёл ли игрок в триггер?
        /// </summary>
        private bool entered;

        /// <summary>
        /// Ссылка на условие прохождения уровня по очкам.
        /// </summary>
        [SerializeField] private LevelConditionScore conditionScore;

        #endregion

        #region API



        #region Unity API

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (conditionScore == null) return;

            if (conditionScore.Reached == false) return;

            if (collision.transform.root.GetComponent<SpaceShip>() == null) return;

            if (collision.transform.root.GetComponent<SpaceShip>() != Player.Instance.ActiveShip) return;

            entered = true;
        }

        #endregion

        #region Public API

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if (entered)
                        achieved = true;
                }

                return achieved;
            }
        }

        #endregion

        #endregion
    }
}