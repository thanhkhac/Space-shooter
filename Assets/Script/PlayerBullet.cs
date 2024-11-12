using UnityEngine;

namespace Script
{
    public class PlayerBullet : MonoBehaviour
    {
        public float speed = 8f;

        void Update()
        {
            Vector2 position = transform.position;
            position = new Vector2(position.x, position.y + speed * Time.deltaTime);
            transform.position = position;
            if (Camera.main != null)
            {
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
                if (transform.position.y > max.y) { Destroy(gameObject); }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("AsteroidTag")) { Destroy(gameObject); }
        }
    }
}