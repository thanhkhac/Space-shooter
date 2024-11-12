using System;
using UnityEngine;

namespace Script
{
    public class StarControl: MonoBehaviour
    {
        GameObject scoreUIText;
        // public GameObject explosionPrefab;
        public float speed = 2f;
        
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
                Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

                if (transform.position.y < min.y)
                {
                    Destroy(gameObject);
                }
            }
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerTag"))
            {
                // GameObject explosion = Instantiate(this.explosionPrefab);
                // explosion.transform.position = transform.position;
                scoreUIText.GetComponent<GameScore>().score += 500;
                if (audioSource != null)
                {
                    audioSource.Play();
                }
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, audioSource.clip.length);
            }
        }
    }
}