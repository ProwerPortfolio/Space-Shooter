using UnityEngine;

namespace SpaceShooter
{
    public class EntitySpawnerDebris : MonoBehaviour
    {
        [SerializeField] private Destructible[] debrisPrefabs;

        [SerializeField] private CircleArea area;

        [SerializeField] private int debrisCount;

        [SerializeField] private float randomSpeed;

        private void Start()
        {
            for (int i = 0; i < debrisCount; i++)
            {
                SpawnDebris();
            }
        }

        private void SpawnDebris()
        {
            int index = Random.Range(0, debrisPrefabs.Length);

            GameObject debris = Instantiate(debrisPrefabs[index].gameObject);

            debris.transform.position = area.GetRandomInsideZone();

            debris.GetComponent<Destructible>().EventOnDeath.AddListener(OnDebrisDead);

            Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();

            if (rb != null && randomSpeed > 0)
            {
                rb.velocity = (Vector2) Random.insideUnitSphere * randomSpeed;
            }
        }

        private void OnDebrisDead()
        {
            SpawnDebris();
        }
    }
}