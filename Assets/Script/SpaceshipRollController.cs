using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipRollController : MonoBehaviour
{
    public float rollSpeed = 1000f; 
    public float maxRollAngle = 45f; 
    public float recoverySpeed = 2f; 
    private float currentRollAngle = 0f; // Góc lăn hiện tại
    private float maxPitchAngle = 10f; // Góc nghiêng trước/sau


    private float currentPitchAngle = 0f; // Góc nghiêng hiện tại (trước/sau)
    void Update()
    {
        // float rollInput = Input.GetAxis("Horizontal"); 
        // if (rollInput > 0) { transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, -45, transform.localEulerAngles.z); }
        // else if (rollInput < 0) { transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 45, transform.localEulerAngles.z); }
        // else { transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 0, transform.localEulerAngles.z); }
        
        // Nhận input cho lăn trái/phải
        float rollInput = Input.GetAxis("Horizontal");
        float targetRollAngle = 0f;
        if (rollInput > 0)
        {
            targetRollAngle = -maxRollAngle;
        }
        else if (rollInput < 0)
        {
            targetRollAngle = maxRollAngle;
        }


        float pitchInput = Input.GetAxis("Vertical");
        float targetPitchAngle = 0f;
        if (pitchInput < 0)
        {
            targetPitchAngle = -maxPitchAngle; 
        }
        else if (pitchInput > 0)
        {
            targetPitchAngle = maxPitchAngle;
        }

        currentRollAngle = Mathf.Lerp(currentRollAngle, targetRollAngle, Time.deltaTime * recoverySpeed);

        currentPitchAngle = Mathf.Lerp(currentPitchAngle, targetPitchAngle, Time.deltaTime * recoverySpeed);

        transform.localRotation = Quaternion.Euler(currentPitchAngle, currentRollAngle, transform.localEulerAngles.z);
    }
}