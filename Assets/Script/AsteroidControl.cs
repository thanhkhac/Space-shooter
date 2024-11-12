using System;
using UnityEngine;

namespace Script
{
    public class AsteroidControl : MonoBehaviour
    {
        GameObject scoreUIText;
        public GameObject explosionPrefab;
        public static float speed = 2f;
        private int lives = 3; 


        private AudioSource audioSource;


        private void Start()
        {
            scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
            audioSource = GetComponent<AudioSource>();
        }
        void Update()
        {
            Vector2 position = transform.position;

            position = new Vector2(position.x, position.y - speed * Time.deltaTime);

            transform.position = position;

            if (Camera.main != null)
            {
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

                if (transform.position.y < min.y) { Destroy(gameObject); }
            }
            speed += 0.0001f;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerTag") || other.CompareTag("PlayerBulletTag"))
            {
                lives--; 
                audioSource.Play();
                GameObject explosion = Instantiate(this.explosionPrefab);
                explosion.transform.position = transform.position;
                if (other.CompareTag("PlayerTag") )
                {
                    scoreUIText.GetComponent<GameScore>().score -= 1000;
                }
                if (lives > 0)
                {
                    return; 
                }
                scoreUIText.GetComponent<GameScore>().score += 100;

                GetComponent<Collider2D>().enabled = false;
                foreach (Transform child in transform) { Destroy(child.gameObject); }
                Destroy(gameObject, audioSource.clip.length);
            }
            

        }
    }
}