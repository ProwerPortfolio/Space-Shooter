using UnityEngine;

namespace SpaceShooter
{
    public class PowerupSpeedUp : PowerupBuff
    {
        private SpaceShip target;

        private float currentShipThrust;

        [SerializeField] private float newSpeed;

        protected override void OnPowerupStart(SpaceShip ship)
        {
            target = ship;

            currentShipThrust = ship.Thrust;

            base.OnPowerupStart(ship);
        }

        protected override void Update()
        {
            if (target != null)
                target.Thrust = newSpeed;

            base.Update();
        }

        protected override void OnPowerupEnd()
        {
            if (target != null)
                target.Thrust = currentShipThrust;

            base.OnPowerupEnd();
        }
    }
}