using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float rotationSpeed = 30f; // Vitesse de rotation de la caméra
    public float maxRotationAngle = 45f; // Angle maximum de rotation à gauche et à droite
    public float rotationOffset = 0f; // Offset de rotation initial
    public GameObject player = null;
    private float currentRotationAngle = 0f;
    private bool rotatingRight = true;

    public ForbiddenAction forbiddenAction = null;

    public void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player not set in SecurityCamera script!");
        }
        if (forbiddenAction == null)
        {
            Debug.LogError("ForbiddenAction not set in SecurityCamera script!");
        }
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float rotationStep = rotationSpeed * Time.deltaTime;

        if (rotatingRight)
        {
            currentRotationAngle += rotationStep;
            if (currentRotationAngle >= maxRotationAngle + rotationOffset)
            {
                rotatingRight = false;
            }
        }
        else
        {
            currentRotationAngle -= rotationStep;
            if (currentRotationAngle <= -maxRotationAngle + rotationOffset)
            {
                rotatingRight = true;
            }
        }

        transform.localRotation = Quaternion.Euler(0f, currentRotationAngle, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Player detected by security camera!");
            forbiddenAction.isActionTriggered = true;
        }
    }
}
