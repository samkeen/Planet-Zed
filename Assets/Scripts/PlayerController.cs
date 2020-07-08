using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("in ms^-1")] [SerializeField] private float controlSpeed = 14f;
    [Tooltip("in m")] [SerializeField] private float xRange = 6f;
    [Tooltip("in m")] [SerializeField] private float yRange = 4f;
    
    [Header("Screen-position based")]
    [SerializeField] private float positionPitchFactor = -5f;
    [SerializeField] private float positionYawFactor = 5f;
    
    [Header("Control-throw based")]
    [SerializeField] private float controlPitchFactor = -10f;
    [SerializeField] private float controlRollFactor = -30f;

    private float xThrow, yThrow;
    private bool isDying = false;

    void OnPlayerDeath() // called by string ref (sendMessage())
    {
        isDying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDying)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    

    private void ProcessRotation()
    {
        /*
         *           Position on screen        control throw
         *   pitch         coupled                 coupled
         *   yaw           coupled                    -
         *   role             -                    coupled
         */
        float pithDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pithDueToPosition + pitchDueToControlThrow;
        
        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}