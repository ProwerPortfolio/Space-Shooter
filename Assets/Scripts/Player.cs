// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    public class Player : MonoSingleton<Player>
    {
        #region Parameters

        /// <summary>
        /// ���������� ������ ������.
        /// </summary>
        [SerializeField] private int livesCount;
        /// <summary>
        /// ������ �� ������� ������� ������.
        /// </summary>
        [SerializeField] private SpaceShip ship;
        /// <summary>
        /// ������ �� ������ ������� ������.
        /// </summary>
        [SerializeField] private GameObject playerShipPrefab;

        /// <summary>
        /// ������ �� CameraController.
        /// </summary>
        [SerializeField] private CameraController cameraController;
        /// <summary>
        /// ������ �� MovementController.
        /// </summary>
        [SerializeField] private MovementController movementController;

        #endregion

        #region API

        /// <summary>
        /// ��������� ������ ��� ����������� ����, ���� ������ �� ��������.
        /// </summary>
        private void OnShipDead()
        {
            livesCount--;

            if (livesCount > 0)
                Respawn();
            else
                LevelSequenceController.Instance.FinishCurrentLevel(false);
        }

        /// <summary>
        /// ���������� ������.
        /// </summary>
        private void Respawn()
        {
            if (LevelSequenceController.PlayerShip != null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);

                ship = newPlayerShip.GetComponent<SpaceShip>();

                cameraController.SetTarget(ship.transform);

                movementController.SetTargetShip(ship);

                ship.EventOnDeath.AddListener(OnShipDead);
            }
        }

        #region Unity API

        /// <summary>
        /// ��������� ������� ������� � ������ � ���������� ���, ���� �� ����.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            if (ship != null)
                Destroy(ship.gameObject);
        }

        private void Start()
        {
            Respawn();
        }

        #endregion

        #region Public API

        public SpaceShip ActiveShip => ship;

        #region Score

        /// <summary>
        /// ���������� ����� ������.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// ���������� ������� ������.
        /// </summary>
        public int KillCount { get; private set; }

        /// <summary>
        /// ��������� ���� ��������.
        /// </summary>
        public void AddKill()
        {
            KillCount++;
        }

        /// <summary>
        /// ��������� ����������� ���������� �����.
        /// </summary>
        /// <param name="count">���������� �����.</param>
        public void AddScore(int count)
        {
            Score += count;
        }

        #endregion

        #endregion

        #endregion
    }
}