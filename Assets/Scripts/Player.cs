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
        /// Количество жизней игрока.
        /// </summary>
        [SerializeField] private int livesCount;
        /// <summary>
        /// Ссылка на текущий корабль игрока.
        /// </summary>
        [SerializeField] private SpaceShip ship;
        /// <summary>
        /// Ссылка на префаб корабля игрока.
        /// </summary>
        [SerializeField] private GameObject playerShipPrefab;

        /// <summary>
        /// Ссылка на CameraController.
        /// </summary>
        [SerializeField] private CameraController cameraController;
        /// <summary>
        /// Ссылка на MovementController.
        /// </summary>
        [SerializeField] private MovementController movementController;

        #endregion

        #region API

        /// <summary>
        /// Респавнит игрока или проигрывает игру, если жизней не осталось.
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
        /// Возраждает игрока.
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
        /// Проверяет наличие корабля у игрока и уничтожает его, если он есть.
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
        /// Количество очков игрока.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Количество убийств игрока.
        /// </summary>
        public int KillCount { get; private set; }

        /// <summary>
        /// Добавляет одно убийство.
        /// </summary>
        public void AddKill()
        {
            KillCount++;
        }

        /// <summary>
        /// Добавляет определённое количество очков.
        /// </summary>
        /// <param name="count">Количество очков.</param>
        public void AddScore(int count)
        {
            Score += count;
        }

        #endregion

        #endregion

        #endregion
    }
}