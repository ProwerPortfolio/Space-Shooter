// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;
using UnityEngine.Events;

#endregion

namespace SpaceShooter
{
    /// <summary>
    /// ������� ��� ����������� ������.
    /// </summary>
    public interface ILevelCondition
    {
        /// <summary>
        /// ������� �� �������?
        /// </summary>
        bool IsCompleted { get; }
    }

    /// <summary>
    /// ���������� ������, ��������� ��� ������� ��� ��� ����������.
    /// </summary>
    public class LevelController : MonoSingleton<LevelController>
    {
        #region Parameters

        /// <summary>
        /// ����� ����������� � ��������, �� ������� ����� ����������� ����.
        /// </summary>
        [SerializeField] private int referenceTime;

        /// <summary>
        /// �������, ������� ���������� ��� ����������� ������.
        /// </summary>
        [SerializeField] private UnityEvent eventLevelCompleted;

        /// <summary>
        /// ������ ���� �����������.
        /// </summary>
        private ILevelCondition[] conditions;

        /// <summary>
        /// ������� �������?
        /// </summary>
        private bool isLevelCompleted;

        /// <summary>
        /// ��������� ����� � ������ ������.
        /// </summary>
        private float levelTime;

        #endregion

        #region API

        /// <summary>
        /// ���������: ��������� �� ��� �������� �������?
        /// </summary>
        private void CheckLevelConditions()
        {
            if (conditions == null || conditions.Length == 0) return;

            int completedCount = 0;

            foreach (var v in conditions)
            {
                if (v.IsCompleted)
                    completedCount++;
            }

            if (completedCount == conditions.Length)
            {
                isLevelCompleted = true;

                eventLevelCompleted?.Invoke();

                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }
        }

        #region Unity API

        private void Start()
        {
            conditions = GetComponentsInChildren<ILevelCondition>();
        }

        private void Update()
        {
            if (!isLevelCompleted)
            {
                levelTime += Time.deltaTime;

                CheckLevelConditions();
            }
        }

        #endregion

        #region Public API

        public int ReferenceTime => referenceTime;

        public float LevelTime => levelTime;

        #endregion

        #endregion
    }
}