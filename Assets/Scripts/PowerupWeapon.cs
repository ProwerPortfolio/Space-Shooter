using UnityEngine;

namespace SpaceShooter
{
    public class PowerupWeapon : Powerup
    {
        [SerializeField] private TurretProperties properties;

        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(properties);
        }
    }
}