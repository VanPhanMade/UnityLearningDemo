using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;
using TMPro;
using FMODUnity;
using UnityEngine.UI;

public class TutorialCharacterInputs : MonoBehaviour
{
    #region Fields
    private RobotFighterInputs ActionMap;

    public event Action<InputAction.CallbackContext> Movement;
    public event Action<InputAction.CallbackContext> Attack;

    [SerializeField] private NavMeshAgent AIAgent;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private Animator AIAnimator;
    [SerializeField] private TextMeshProUGUI TutorialText;

    [SerializeField] private Slider HealthSlider;

    [SerializeField] private EventReference DialogueSFX;
    #endregion

    #region Unity
    private void Awake()
    {
        ActionMap = new();
        if (AIAgent == null) AIAgent = GetComponent<NavMeshAgent>();
        if (AIAnimator == null) AIAnimator = GetComponent<Animator>();

    }
    private void OnDisable()
    {
        ActionMap.Disable();
    }
    private void OnEnable()
    {
        ActionMap.Enable();
        ActionMap.Player.PrimaryAction.performed += OnMovement;
        ActionMap.Player.SecondaryAction.performed += OnAttack;
        ChangeTutorialText("Move around with left click");

        // Initial info
        Movement += (ctx) => {
            Vector3 screenPosition = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out RaycastHit HitData, 500, Ground))
            {
                Debug.DrawLine(Camera.main.transform.position, HitData.point, Color.red, 10);
                AIAgent.destination = HitData.point;
            }
        };

        Attack += (ctx) =>
        {
            HealthSlider.value -= 10;
            Debug.Log("Default attack");
        };
    }

    private void FixedUpdate()
    {
        AIAnimator.SetFloat("Speed", AIAgent.velocity.magnitude);
    }
    #endregion

    #region TutorialCharacterInputs
    private void OnMovement(InputAction.CallbackContext ctx)
    {
        Movement?.Invoke(ctx);
    }
    private void OnAttack(InputAction.CallbackContext ctx)
    {
        Attack?.Invoke(ctx);
    }
    public void ClearAttack()
    {
        Attack = null;
    }

    public void ChangeTutorialText(string newText)
    {
        FmodEvents.PlayOneShot(DialogueSFX, transform.position);
        TutorialText.SetText(newText);
    }
    #endregion

}
