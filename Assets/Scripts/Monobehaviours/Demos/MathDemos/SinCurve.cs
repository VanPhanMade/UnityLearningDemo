using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinCurve : MonoBehaviour
{
    [SerializeField] float SinPeriod = 1f; //The length from each peak
    [SerializeField] float SinMagnitude = 1f; //The amplitude/height of the peak

    private Vector3 originalPos;
    private float elapsedTime;

    private void Start()
    {
        originalPos = transform.position;
    }

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime * SinPeriod;
        transform.position = new Vector3(originalPos.x, Mathf.Sin(elapsedTime) * SinMagnitude, originalPos.z);
    }
}
