using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script
{
    public class PlayerControl : MonoBehaviour
    {
        public GameObject gameManager;
        public GameObject gameOverCanvas;
        public float speed = 5f;
        private readonly float _playerSize = 1f;
        public GameObject explosionPrefab;
        const int Maxlives = 3;
        private int lives;
        
        public List<Image> heartImages; 


        public void Start()
        {
            lives = Maxlives;
        }

        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            Vector2 direction = new Vector2(x, y);
            // Vector2 direction = new Vector2(x, y).normalized;

            Move(direction);
        }

        void Move(Vector2 direction)
        {
            if (Camera.main != null)
            {
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 

                max.x = max.x - _playerSize;
                min.x = min.x + _playerSize;

                max.y = max.y - _playerSize;
                min.y = min.y + _playerSize;

                Vector2 pos = transform.position;

                pos += direction * (speed * Time.deltaTime);

                pos.x = Mathf.Clamp(pos.x, min.x, max.x);
                pos.y = Mathf.Clamp(pos.y, min.y, max.y);

                transform.position = pos;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("AsteroidTag"))
            {
                lives--;
                heartImages[lives].enabled = false;
                if (lives <= 0)    
                {
                    GameObject explosion = Instantiate(this.explosionPrefab);
                    explosion.transform.position = transform.position;
                    gameOverCanvas.SetActive(true);
                    gameManager.GetComponent<GameManager>().EndGame();
                    Destroy(gameObject);
                }
            }
        }
    }
}