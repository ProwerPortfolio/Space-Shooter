// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ������� ���������� ������ �� �����.
    /// </summary>
    public class LevelConditionScore : MonoBehaviour, ILevelCondition
    {
        #region Parameters

        /// <summary>
        /// ����������� ���������� ����� ��� ����������� ������.
        /// </summary>
        [SerializeField] private int score;

        /// <summary>
        /// �������� �� ����������� ���������� �����?
        /// </summary>
        private bool reached;

        #endregion

        #region API



        #region Unity API



        #endregion

        #region Public API

        public bool Reached => reached;

        /// <summary>
        /// ���������� ��������� �������� �� ����������� ���������� �����.
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