using UnityEngine;

namespace Script
{
    public class PlayerShoot : MonoBehaviour
    {
        public GameObject playerBullet;
        public GameObject playerGun1;
        public GameObject playerGun2;

        public float fireRate = 0.1f; 
        private float _timeSinceLastShot = 0f;

        public void Update()
        {
            _timeSinceLastShot += Time.deltaTime;

            if (Input.GetMouseButton(0) && _timeSinceLastShot >= fireRate)
            {
                _timeSinceLastShot = 0f;

                GameObject bullet1 = Instantiate(playerBullet);
                bullet1.transform.position = playerGun1.transform.position;
                GameObject bullet2 = Instantiate(playerBullet);
                bullet2.transform.position = playerGun2.transform.position;
            }
        }
    }
}
