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
    private event Action<InputAction.CallbackContext> Cancel;

    private void Awake()
    {
        ActionMap = new();
    }

    private void OnEnable()
    {
        ActionMap.Enable();
        BaseLocomotion baseLocomotion = MovementType.GetComponent<BaseLocomotion>();

        ActionMap.Player.Movement.canceled += baseLocomotion.OnMovementCancelled;
        ActionMap.Player.Movement.performed += baseLocomotion.OnMovementPerformed;
        baseLocomotion.playerTransform = transform;

        BaseSingleInput lightAttack = LightAttackType.GetComponent<BaseSingleInput>();
        LightAttack += lightAttack.OnActionPerformed;
      
        BaseSingleInput heavyAttack = HeavyAttackType.GetComponent<BaseSingleInput>();
        HeavyAttack += heavyAttack.OnActionPerformed;

        ActionMap.Player.LightAttack.performed += OnLightAttack;
        ActionMap.Player.HeavyAttack.performed += OnHeavyAttack;
    }

    private void OnDisable()
    {
        ActionMap.Disable();
    }

    private void OnLightAttack(InputAction.CallbackContext ctx)
    {
        LightAttack.Invoke(ctx);
    }

    private void OnHeavyAttack(InputAction.CallbackContext ctx)
    {
        HeavyAttack.Invoke(ctx);
    }

    private void OnMovementPerformed(InputAction.CallbackContext ctx)
    {

    }

    private void OnMovementCancel(InputAction.CallbackContext ctx)
    {

    }
}
