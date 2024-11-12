using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class Spawner : MonoBehaviour
    {
        //Prefab    
        public GameObject asteroid;
        public GameObject star;
        public float spawnRatePerSecond = 5f;
        void Start()
        {
            Invoke("SpawnAsteroid", spawnRatePerSecond);
            InvokeRepeating("IncreaseSpawnRate", 0f, 5f);
        }


        void SpawnAsteroid()
        {
            if (Camera.main != null)
            {
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

                GameObject newAsteroid = Instantiate(asteroid);
                newAsteroid.transform.position = new Vector2(Random.Range(min.x +1f, max.x-1f), max.y-1f);
            }
            ScheduleNextSpawn();
        }
        
        void SpawnStar()
        {
            if (Camera.main != null)
            {
                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

                GameObject newStar = Instantiate(star);
                newStar.transform.position = new Vector2(Random.Range(min.x +1f, max.x-1f), max.y-1f);
            }
            // ScheduleNextSpawn();
        }

        void ScheduleNextSpawn()
        {
            float spawnInNSeconds;

            if (spawnRatePerSecond > 1f) { spawnInNSeconds = Random.Range(1f, spawnRatePerSecond); }
            else { spawnInNSeconds = 1f; }

            Invoke("SpawnAsteroid", spawnInNSeconds);
            Invoke("SpawnStar", spawnInNSeconds);
        }

        void IncreaseSpawnRate()
        {
            if (spawnRatePerSecond > 1f)
                {spawnRatePerSecond--;}

            if (spawnRatePerSecond == 1f) { CancelInvoke("IncreaseSpawnRate"); }
        }
        
    
        public void StopSpawn()
        {
            CancelInvoke("SpawnAsteroid");
            CancelInvoke("SpawnStar");
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}