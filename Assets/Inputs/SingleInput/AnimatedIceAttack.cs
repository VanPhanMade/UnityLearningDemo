using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using FMODUnity;

public class AnimatedIceAttack : BaseSingleInput
{
    [SerializeField] private Animator AttackAnimator;
    [SerializeField] private EventReference IceAttackSFX;
    public override void OnActionCancelled(InputAction.CallbackContext ctx)
    {
        
    }

    public override void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        GameObject spawnedIceAttack = Instantiate(this.gameObject);
        FmodEvents.PlayOneShot(IceAttackSFX, playerTransform.position);
        spawnedIceAttack.transform.position = playerTransform.position;
        spawnedIceAttack.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), -playerTransform.right );

        Debug.DrawLine(spawnedIceAttack.transform.position, spawnedIceAttack.transform.position + spawnedIceAttack.transform.forward * 10, Color.red, 1);
    }

    public void OnEnable()
    {
        AttackAnimator = GetComponent<Animator>();
        AttackAnimator.Play("IceMovement");
        Invoke(nameof(SelfClean), 5);
    }

    public void SelfClean()
    {
        Destroy(this.gameObject);
    }
}
