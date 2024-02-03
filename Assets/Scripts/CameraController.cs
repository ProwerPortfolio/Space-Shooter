using UnityEngine;

namespace SpaceShooter
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;

        [SerializeField] private Transform target;

        [SerializeField] private float interpolationSpeed;

        [SerializeField] private float interpolationAngular;

        [SerializeField] private float cameraZOffset;

        [SerializeField] private float forwardOffset;

        private void Update()
        {
            if (m_camera == null || target == null) return;

            Vector2 cameraPosition = m_camera.transform.position;
            Vector2 targetPosition = target.position + target.transform.up * forwardOffset;

            Vector2 newCameraPosition = Vector2.Lerp(cameraPosition, targetPosition, interpolationSpeed * Time.deltaTime);

            m_camera.transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, cameraZOffset);

            if (interpolationAngular > 0)
            {
                m_camera.transform.rotation = Quaternion.Slerp(m_camera.transform.rotation, target.rotation, interpolationAngular * Time.deltaTime);
            }
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }
    }
}