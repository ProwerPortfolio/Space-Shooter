using UnityEngine;

namespace SpaceShooter
{
    public abstract class PowerupBuff : Powerup
    {
        [SerializeField] private Color buffColor;

        [SerializeField] private float buffTime;

        private SpriteRenderer spriteRenderer;

        private float timer;

        private void Awake()
        {
            enabled = false;
        }

        protected virtual void OnPowerupStart(SpaceShip ship)
        {
            spriteRenderer = ship.GetComponentInChildren<SpriteRenderer>();

            enabled = true;

            timer = 0;
        }

        protected override void OnPickedUp(SpaceShip ship)
        {
            OnInstantiate(ship);
        }

        private void OnInstantiate(SpaceShip ship)
        {
            PowerupBuff buff = Instantiate(this);

            SpriteRenderer sprite = buff.GetComponentInChildren<SpriteRenderer>();
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);

            CircleCollider2D collider2D = buff.GetComponent<CircleCollider2D>();
            collider2D.enabled = false;

            buff.OnPowerupStart(ship);
        }

        protected virtual void Update()
        {
            timer += Time.deltaTime;

            if (spriteRenderer != null)
                spriteRenderer.color = buffColor;

            if (timer > buffTime)
            {
                OnPowerupEnd();
                enabled = false;
            }
        }

        protected virtual void OnPowerupEnd()
        {
            if (spriteRenderer != null)
                spriteRenderer.color = new Color(1, 1, 1);

            enabled = false;

            Destroy(gameObject);
        }
    }
}