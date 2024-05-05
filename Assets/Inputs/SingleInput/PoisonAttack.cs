using UnityEngine;
using UnityEngine.InputSystem;

public class PoisonAttack : BaseSingleInput
{
    public override void OnActionCancelled(InputAction.CallbackContext ctx)
    {

    }

    public override void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Poison Attack");
    }
}
