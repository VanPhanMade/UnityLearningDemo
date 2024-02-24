using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionEuler : MonoBehaviour
{
    [SerializeField] private Vector3 DeltaEulerVector;

    private Vector3 currentRotation;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        currentRotation = transform.rotation.eulerAngles;
    }
    void FixedUpdate()
    {
        currentRotation += DeltaEulerVector;
        transform.rotation = Quaternion.Euler(currentRotation);
    }
}
