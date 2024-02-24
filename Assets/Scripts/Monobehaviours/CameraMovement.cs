using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] [Range(0, 10)] private float lookSpeed = 2f;
    [SerializeField] [Range(0, 60)] private float lookPitchLimit = 60f;

    float currentPitch = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentPitch += -Input.GetAxis("Mouse Y") * lookSpeed;
        currentPitch = Mathf.Clamp(currentPitch, -lookPitchLimit, lookPitchLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(currentPitch, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}
