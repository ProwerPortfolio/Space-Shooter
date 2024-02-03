// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ������� ���������� ������ �� ���������� �������.
    /// </summary>
    [RequireComponent(typeof(CircleCollider2D))]
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        #region Parameters

        /// <summary>
        /// ���������� �� ����������� �������?
        /// </summary>
        private bool achieved;

        /// <summary>
        /// ����� �� ����� � �������?
        /// </summary>
        private bool entered;

        /// <summary>
        /// ������ �� ������� ����������� ������ �� �����.
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