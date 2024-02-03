// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// Условие завершения уровня по очкам.
    /// </summary>
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        #region Parameters

        /// <summary>
        /// Необходимое количество очков для прохождения уровня.
        /// </summary>
        [SerializeField] private int score;

        /// <summary>
        /// Получено ли необходимое количество очков?
        /// </summary>
        private bool reached;

        #endregion

        #region API



        #region Unity API



        #endregion

        #region Public API

        public bool Reached => reached;

        /// <summary>
        /// Возвращает результат проверки на необходимое количество очков.
        /// </summary>
        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if (Player.Instance.Score >= score)
                    {
                        reached = true;
                    }
                }

                return reached;
            }
        }

        #endregion

        #endregion
    }
}