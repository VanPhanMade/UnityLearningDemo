using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 4f;
    void OnEnable()
    {
        Invoke("SelfClean", 10);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }

    void SelfClean()
    {
        Destroy(gameObject);
    }
}
