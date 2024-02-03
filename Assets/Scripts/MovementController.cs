using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер для управления кораблём.
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        public enum ControlMode
        {
            Keyboard,
            VirtualJoystick
        }

        [SerializeField] private SpaceShip targetShip;

        [SerializeField] private VirtualJoystick virtualJoystick;

        [SerializeField] private ControlMode controlMode;

        public void SetTargetShip(SpaceShip ship) => targetShip = ship;

        [SerializeField] private PointerClickHold mobileFirePrimary;
        [SerializeField] private PointerClickHold mobileFireSecondary;

        private void Start()
        {
            if (Application.isMobilePlatform)
                controlMode = ControlMode.VirtualJoystick;
            
            if (controlMode == ControlMode.Keyboard)
            {
                virtualJoystick.gameObject.SetActive(false);

                mobileFirePrimary.gameObject.SetActive(false);
                mobileFireSecondary.gameObject.SetActive(false);
            }

            if (controlMode == ControlMode.VirtualJoystick)
            {
                virtualJoystick.gameObject.SetActive(true);

                mobileFirePrimary.gameObject.SetActive(true);
                mobileFireSecondary.gameObject.SetActive(true);
            }
        }

        private void Update()
        {
            if (targetShip == null) return;

            if (controlMode == ControlMode.Keyboard)
                ControlKeyboard();

            if (controlMode == ControlMode.VirtualJoystick)
                ControlVirtualJoystick();
        }

        private void ControlKeyboard()
        {
            float thrust = 0;
            float torque = 0;

            if (Input.GetKey(KeyCode.W))
                thrust = 1.0f;

            if (Input.GetKey(KeyCode.S))
                thrust = -1.0f;

            if (Input.GetKey(KeyCode.A))
                torque = 1.0f;

            if (Input.GetKey(KeyCode.D))
                torque = -1.0f;

            targetShip.ThrustControl = thrust;
            targetShip.TorqueControl = torque;

            if (Input.GetMouseButton(0))
            {
                targetShip.Fire(TurretMode.Primary);
            }

            if (Input.GetMouseButton(1))
            {
                targetShip.Fire(TurretMode.Secondary);
            }
        }

        private void ControlVirtualJoystick()
        {
            var dir = virtualJoystick.Value;
            targetShip.ThrustControl = dir.y;
            targetShip.TorqueControl = -dir.x;

            if (mobileFirePrimary.IsHold)
            {
                targetShip.Fire(TurretMode.Primary);
            }

            if (mobileFireSecondary.IsHold)
            {
                targetShip.Fire(TurretMode.Secondary);
            }

            /*
            Vector3 dir = virtualJoystick.Value;

            var dot = Vector2.Dot(dir, targetShip.transform.up);
            var dot2 = Vector2.Dot(dir, targetShip.transform.right);

            targetShip.ThrustControl = Mathf.Max(0, dot);
            targetShip.TorqueControl = -dot2;
            */
        }
    }
}
