using UnityEngine;

namespace Script
{
    public class Spin : MonoBehaviour
    {
        public float rotationSpeed = 100f; 

        void Update()
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}

