using UnityEngine;

namespace SpaceShooter
{
    public class Asteroid : Destructible
    {
        [SerializeField] private int asteroidsCount;

        private Asteroid asteroid;

        protected override void OnDeath()
        {
            if (this.transform.localScale.x > 0.3f || this.transform.localScale.y > 0.3f || this.transform.localScale.z > 0.3f)
            {
                for (int i = 0; i < asteroidsCount; i++)
                {
                    asteroid = Instantiate(this);
                    asteroid.SetHealth(StartHitPoints);
                    asteroid.transform.localScale = transform.localScale / 2;
                    asteroid.SetHealth(StartHitPoints / 2);
                }
            } 
                
            base.OnDeath();            
        }
    }
}