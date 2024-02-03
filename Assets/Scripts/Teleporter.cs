using UnityEngine;

namespace SpaceShooter
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision?.transform.root.GetComponent<SpaceShip>();

            if (ship == null || target == null) return;

            ship.transform.position = target.position;
            ship.DontDestroyEnable();
        }
    }
}