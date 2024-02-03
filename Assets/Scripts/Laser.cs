using UnityEngine;

namespace SpaceShooter
{
    public class Laser : MonoBehaviour
    {
        [SerializeField] private GameObject line;

        private enum Condition
        {
            Off,
            Warning,
            Fire
        }

        [SerializeField] private Condition condition;

        /// <summary>
        /// Время, которое лазер будет отключен.
        /// </summary>
        [Header("Settings")]
        [SerializeField] private float timeOff;

        /// <summary>
        /// Время, которое лазер будет предупреждать о выстреле.
        /// </summary>
        [SerializeField] private float timeWarning;

        /// <summary>
        /// Время, которое лазер будет стрелять.
        /// </summary>
        [SerializeField] private float timeFire;

        private float time;

        private ParticleSystem particles;
        private Collider2D killCollider;

        private void Start()
        {
            particles = line.GetComponentInChildren<ParticleSystem>();
            killCollider = line?.GetComponent<Collider2D>();

            if (particles == null || line == null || killCollider == null) return;

            UpdateCondition();
        }

        private void Update()
        {
            time += Time.deltaTime;

            if (particles == null || line == null || killCollider == null) return;

            if (condition == Condition.Off && time >= timeOff)
            {
                condition = Condition.Warning;
                UpdateCondition();
                time = 0;
            }

            if (condition == Condition.Warning && time >= timeWarning)
            {
                condition = Condition.Fire;
                UpdateCondition();
                time = 0;
            }

            if (condition == Condition.Fire && time >= timeFire)
            {
                condition = Condition.Off;
                UpdateCondition();
                time = 0;
            }
        }

        private void UpdateCondition()
        {
            if (particles == null || line == null || killCollider == null) return;

            if (condition == Condition.Off)
            {
                line.SetActive(false);
            }

            if (condition == Condition.Warning)
            {
                line.SetActive(true);
                killCollider.enabled = false;
                particles.gameObject.SetActive(false);
            }

            if (condition == Condition.Fire)
            {
                line.SetActive(true);
                killCollider.enabled = true;
                particles.gameObject.SetActive(true);
            }
        }
    }
}