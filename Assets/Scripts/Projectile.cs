// Created and owned by Sankoh_Tew. Hi, dataminers! ;)

#region Usings

using UnityEngine;

#endregion

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        #region Parameters

        [SerializeField] protected float velocity;

        [SerializeField] private float lifeTime;

        [SerializeField] private int damage;

        [SerializeField] private ImpactEffect ImpactEffectPrefab;

        public int parentID;

        protected float stepLenght;

        protected Vector2 step;

        private float timer;

        #endregion

        #region API

        protected virtual void OnProjectileLifeEnd()
        {
            Destroy(gameObject);
        }

        #region Unity API

        protected void Update()
        {
            stepLenght = Time.deltaTime * velocity;

            step = transform.up * stepLenght;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLenght);

            if (hit)
            {
                Destructible destructible = hit.transform.root.GetComponent<Destructible>();

                SpaceShip potencialShip;

                if (destructible != null)
                    potencialShip = destructible.GetComponent<SpaceShip>();
                else
                    potencialShip = null;

                if (destructible != null)
                {
                    if (potencialShip != null && potencialShip.ID != parentID)
                        potencialShip.ApplyDamage(damage, parentID);
                    else
                    {
                        if (potencialShip == null)
                            destructible.ApplyDamage(damage);
                    }  

                    if (parentID == Player.Instance.ActiveShip.ID)
                    {
                        Player.Instance.AddScore(destructible.ScoreValue);
                    }

                    // Я хочу, чтобы снаряды пролетали сквозь стены.
                    
                    OnProjectileLifeEnd();
                }
            }

            timer += Time.deltaTime;

            if (timer >= lifeTime)
                Destroy(gameObject);

            transform.position += new Vector3(step.x, step.y, 0);
        }

        #endregion

        #region Public API

        #endregion

        #endregion
    }
}