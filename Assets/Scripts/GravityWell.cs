using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GravityWell : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private float radius;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody == null) return;

            Vector2 dir = transform.position - collision.transform.position;

            float dist = dir.magnitude;

            if (dist < radius)
            {
                Vector2 force = dir.normalized * this.force * (radius / dist);

                collision.attachedRigidbody.AddForce(force, ForceMode2D.Force);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = radius;
        }
#endif

    }
}