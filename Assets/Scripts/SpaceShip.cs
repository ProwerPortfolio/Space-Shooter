// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        #region Parameters

        /// <summary>
        /// Масса корабля для автоматической установки у ригида.
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float mass;

        /// <summary>
        /// Толкающая вперёд сила.
        /// </summary>
        [SerializeField] private float thrust;

        /// <summary>
        /// Вращающая сила.
        /// </summary>
        [SerializeField] private float mobility;

        /// <summary>
        /// Максимальная линейная скорость.
        /// </summary>
        [SerializeField] private float maxLinearVelocity;

        /// <summary>
        /// Максимальная вращательная скорость. В градусах/сек.
        /// </summary>
        [SerializeField] private float maxAngularVelocity;

        /// <summary>
        /// Идентификатор корабля.
        /// </summary>
        public int iD;

        [SerializeField] private Turret[] turrets;

        [SerializeField] private int maxEnergy;

        [SerializeField] private int maxAmmo;

        [SerializeField] private int energyRegenPerSecond;

        /// <summary>
        /// Ссылка на превьюшку корабля.
        /// </summary>
        [SerializeField] private Sprite previewImage;

        /// <summary>
        /// Сохранённая ссылка на ригид.
        /// </summary>
        private Rigidbody2D rigid;

        private float primaryEnergy;

        private int secondaryAmmo;

        #endregion

        #region API

        /// <summary>
        /// Метод добавления сил кораблю для движения
        /// </summary>
        private void UpdateRigidBody()
        {
            rigid.AddForce(ThrustControl * thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            rigid.AddForce(-rigid.velocity * (thrust / maxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            rigid.AddTorque(TorqueControl * mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            rigid.AddTorque(-rigid.angularVelocity * (mobility / maxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        private void InitOffensive()
        {
            primaryEnergy = maxEnergy;

            secondaryAmmo = maxAmmo;
        }

        private void UpdateEnergyRegen()
        {
            primaryEnergy += (float)energyRegenPerSecond * Time.fixedDeltaTime;
            primaryEnergy = Mathf.Clamp(primaryEnergy, 0, maxEnergy);
        }

        #region Unity API

        private void FixedUpdate()
        {
            UpdateRigidBody();

            UpdateEnergyRegen();
        }

        protected override void Start()
        {
            base.Start();

            rigid = GetComponent<Rigidbody2D>();

            rigid.mass = mass;

            rigid.inertia = 1;

            InitOffensive();
        }

        #endregion

        #region Public API

        public float Thrust
        {
            get => thrust;

            set
            {
                if (value < 0) return;

                thrust = value;
            }
        }

        /// <summary>
        /// Управление линейной тягой. От -1.0 до 1.0.
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Управление вращательной тягой. От -1.0 до 1.0.
        /// </summary>
        public float TorqueControl { get; set; }

        public float MaxLinearVelocity => maxLinearVelocity;

        public float MaxAngularVelocity => maxAngularVelocity;

        public Rigidbody2D Rigid => rigid;

        public Sprite PreviewImage => previewImage;

        public int ID => iD;

        public float PrimaryEnergy => primaryEnergy;

        public int SecondaryAmmo => secondaryAmmo;

        public void Fire(TurretMode mode)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                if (turrets[i].Mode == mode)
                {
                    turrets[i].Fire();
                }
            }
        }

        public void AddEnergy(int energy)
        {
            primaryEnergy = Mathf.Clamp(primaryEnergy + energy, 0, maxEnergy);
        }

        public void AddAmmo(int ammo)
        {
            secondaryAmmo = Mathf.Clamp(secondaryAmmo + ammo, 0, maxAmmo);
        }

        public bool DrawAmmo(int count)
        {
            if (count == 0) return true;

            if (secondaryAmmo >= count)
            {
                secondaryAmmo -= count;
                return true;
            }

            return false;
        }

        public bool DrawEnergy(int count)
        {
            if (count == 0) return true;

            if (primaryEnergy >= count)
            {
                primaryEnergy -= count;
                return true;
            }

            return false;
        }

        public void AssignWeapon(TurretProperties properties)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                turrets[i].AssignLoadout(properties);
            }
        }

        #region Score

        public int Score { get; private set; }

        public float KillsCount { get; private set; }

        public void AddKill()
        {
            KillsCount++;
        }

        public void AddScore(int count)
        {
            Score += count;
        }

        #endregion

        #endregion

        #endregion
    }
}