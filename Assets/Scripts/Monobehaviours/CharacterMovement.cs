using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects.CreatureStats;
using System;

namespace Monobehaviours.CharacterMovement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        #region Fields
        [SerializeField] private CreatureStats PlayerStats;
        [SerializeField] private CharacterController characterController;
        [SerializeField][Range(0,100)][Tooltip("This changes how fast the player moves with WASD")] private float walkSpeed = 10.0f;

        private Vector3 MovementDirection;

        private float airTime;
        #endregion

        #region UNITY
        private void Awake()
        {
            if (walkSpeed == 0) throw new System.Exception($"CharacterMovement ({this.gameObject.name}): Default walkSpeed currently zero.");
        }

        private void Start()
        {
            if (PlayerStats == null) throw new System.Exception($"CharacterMovement ({this.gameObject.name}): Player Stats not assigned.");
            else walkSpeed = PlayerStats.Speed;

            if (characterController == null) characterController = GetComponent<CharacterController>();
            if (characterController == null) throw new System.Exception($"CharacterMovement ({this.gameObject.name}): Character controller not assigned.");
        }

        public virtual void Update()
        {
            MovePlayer();
            Jump();
            characterController.Move(Time.deltaTime * MovementDirection);
        }
        #endregion

        #region CharacterMovement
        public virtual void MovePlayer()
        {
            float inputHorizontal = Input.GetAxisRaw("Horizontal");
            float inputVertical = Input.GetAxisRaw("Vertical");
            if (inputHorizontal == 0 && inputVertical == 0)
            {
                MovementDirection = new Vector3(0, MovementDirection.y, 0);
            }

            MovementDirection = (walkSpeed * ((transform.forward * inputVertical) + (transform.right * inputHorizontal)).normalized) + new Vector3(0, MovementDirection.y, 0);
        }

        public virtual void Jump()
        {
            airTime += Time.deltaTime;
            if (Input.GetButton("Jump") && characterController.isGrounded)
            {
                MovementDirection += new Vector3(0, 5, 0);
                airTime = 0;
            }

            if (!characterController.isGrounded && airTime > .5)
            {
                MovementDirection += new Vector3(0, -9.8f * Time.deltaTime, 0);
            }

        }
        #endregion

    }
}

