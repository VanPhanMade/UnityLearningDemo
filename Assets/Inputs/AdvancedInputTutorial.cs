using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class AdvancedInputTutorial : MonoBehaviour
{

    [SerializeField] GameObject MovementType;
    [SerializeField] GameObject LightAttackType;
    [SerializeField] GameObject HeavyAttackType;

    private _2D_CharacterMovement ActionMap;

    private event Action<InputAction.CallbackContext> LightAttack;
    private event Action<InputAction.CallbackContext> HeavyAttack;
    private event Action<InputAction.CallbackContext> Movement;
    private event Action<InputAction.CallbackContext> MovementCancel;

    public static Vector2 CurrentDirectionInput;

    private void Awake()
    {
        ActionMap = new();
    }

    private void OnEnable()
    {
        // Binds inputs to callbacks for input map
        ActionMap.Enable();
        ActionMap.Player.LightAttack.performed += OnLightAttack;
        ActionMap.Player.HeavyAttack.performed += OnHeavyAttack;
        ActionMap.Player.Movement.canceled += OnMovementCancel;
        ActionMap.Player.Movement.performed += OnMovementPerformed;

        // Binds actions from type of ability/movement we have equipped to input callback events
        BaseLocomotion baseLocomotion = MovementType.GetComponent<BaseLocomotion>();
        baseLocomotion.playerTransform = transform;
        Movement += baseLocomotion.OnMovementPerformed;
        MovementCancel += baseLocomotion.OnMovementCancelled;

        BaseSingleInput lightAttack = LightAttackType.GetComponent<BaseSingleInput>();
        lightAttack.playerTransform = transform;
        LightAttack += lightAttack.OnActionPerformed;
      
        BaseSingleInput heavyAttack = HeavyAttackType.GetComponent<BaseSingleInput>();
        heavyAttack.playerTransform = transform;
        HeavyAttack += heavyAttack.OnActionPerformed;

        ActionMap.Player.Jump.performed += OnJumpPerformed;
    }

    private void OnDisable()
    {
        ActionMap.Disable();
    }

    private void OnLightAttack(InputAction.CallbackContext ctx)
    {
        Debug.Log("Light attack");
        LightAttack?.Invoke(ctx);
    }

    private void OnHeavyAttack(InputAction.CallbackContext ctx)
    {
        Debug.Log("Heavy attack");
        HeavyAttack?.Invoke(ctx);
    }

    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        AdvancedInputTutorial.CurrentDirectionInput = ctx.ReadValue<Vector2>();
        Movement?.Invoke(ctx);
        // Debug.Log($"Input x: {AdvancedInputTutorial.CurrentDirectionInput.x} , y {AdvancedInputTutorial.CurrentDirectionInput.y}");
    }

    private void OnMovementCancel(InputAction.CallbackContext ctx)
    {
        MovementCancel?.Invoke(ctx);
    }

    private void OnJumpPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jumped");
    }


}
