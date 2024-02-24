using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Monobehaviours.Missile
{

    public class MissleMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody Rigidbody;
        [SerializeField] AnimationCurve LerpCurve;

        private float elapsedTime = 0f;
        private float speed = 10f;
        private float missileLifeTime = 10f;

        public event Action MissleOutOfGas;

        #region Unity
        private void Awake()
        {
            if (Rigidbody == null) Rigidbody = GetComponent<Rigidbody>();
            if (Rigidbody == null) throw new System.Exception($"MissleMovement ({this.gameObject.name}): Missing RigidBody");
        }

        private void OnEnable()
        {
            elapsedTime = 0;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            elapsedTime += Time.deltaTime;
            Rigidbody.velocity = transform.up * speed * LerpCurve.Evaluate(elapsedTime);
            if (elapsedTime >= missileLifeTime) MissleOutOfGas?.Invoke();
        }
        #endregion

        #region MissileMovement
        public void Init(float newSpeed)
        {
            speed = newSpeed;
            missileLifeTime = 10f;
            elapsedTime = 0f;
        }
        #endregion
    }
}

