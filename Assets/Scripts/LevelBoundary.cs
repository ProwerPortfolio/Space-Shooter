using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceShooter
{
    public class LevelBoundary : MonoSingleton<LevelBoundary>
    {
        [SerializeField] private float radius;
        public float Radius => radius;

        public enum Mode
        {
            Limit,
            Teleport
        }

        [SerializeField] private Mode limitMode;
        public Mode LimitMode => limitMode;

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, transform.forward, radius);
        }
#endif

    }

}