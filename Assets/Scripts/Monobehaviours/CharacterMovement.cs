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
        }
        #endregion

        #region CharacterMovement
        public virtual void MovePlayer()
        {
            float inputHorizontal = Input.GetAxisRaw("Horizontal");
            float inputVertical = Input.GetAxisRaw("Vertical");
            if (inputHorizontal == 0 && inputVertical == 0) return;

            Vector3 MoveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;
            MoveDirection = MoveDirection.normalized;
            Debug.DrawLine(transform.position, transform.position + (transform.forward * 10f * inputVertical), Color.red);
            Debug.DrawLine(transform.position, transform.position + (transform.right * 10f * inputHorizontal), Color.green);
            Debug.DrawLine(transform.position, transform.position + (MoveDirection * 10f), Color.magenta);

            characterController.Move(Time.deltaTime * walkSpeed * MoveDirection);
        }

        public virtual void Jump()
        {
            if (Input.GetButton("Jump") && characterController.isGrounded)
            {
                characterController.Move(new Vector3(0, 3, 0));
            }
            if (!characterController.isGrounded)
            {
                characterController.Move(new Vector3(0, -9.8f * Time.deltaTime, 0));
            }
        }
        #endregion

    }
}

