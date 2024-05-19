using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using FMODUnity;
using TMPro;

public class HealthChangeEnemyEvents : MonoBehaviour
{
    [SerializeField] Animator AIAnimator;
    [SerializeField] Animator TextAnimator;
    [SerializeField] private TextMeshProUGUI DamageTextNumber;
    [SerializeField] private EventReference OnHitSFX;
    public void EnemyHealthChange(float newValue)
    {
        AIAnimator.Play("Head Hit");
        TextAnimator.Play("DamageButtonText");
        DamageTextNumber.text = "10 Damage!";
        FmodEvents.PlayOneShot(OnHitSFX, transform.position);
        Debug.Log(newValue);

    }
}
