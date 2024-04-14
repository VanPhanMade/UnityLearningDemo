using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingMovement : BaseLocomotion
{
    public override void OnMovementCancelled(InputAction.CallbackContext ctx)
    {
        
    }

    public override void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Fly");
    }
}
