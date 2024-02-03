using UnityEngine;

namespace SpaceShooter
{
    public class Turret : MonoBehaviour
    {
        #region ���������

        [SerializeField] private TurretMode mode;
        public TurretMode Mode => mode;

        [SerializeField] private TurretProperties turretProperties;

        private float refireTimer;

        public bool IsCanFire => refireTimer <= 0;

        private SpaceShip ship;

        #endregion

        #region ������ Unity

        private void Start()
        {
            ship = transform.root.GetComponent<SpaceShip>();
        }

        private void Update()
        {
            if (refireTimer > 0)
                refireTimer -= Time.deltaTime;
        }

        #endregion

        #region ��������� API

        public void Fire()
        {
            if (turretProperties == null) return;

            if (!IsCanFire) return;

            if (ship.DrawEnergy(turretProperties.EnergyUsage) == false) return;

            if (ship.DrawAmmo(turretProperties.AmmoUsage) == false) return;

            Projectile projectile = Instantiate(turretProperties.ProjectilePrefab).GetComponent<Projectile>();
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;

            projectile.parentID = ship.ID;

            refireTimer = turretProperties.RateOfFire;

            // SFX
        }

        public void AssignLoadout(TurretProperties properties)
        {
            if (mode != properties.Mode) return;

            refireTimer = 0;
            turretProperties = properties;
        }

        #endregion
    }
}