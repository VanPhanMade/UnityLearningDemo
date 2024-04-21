using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : BaseLocomotion
{
    // Speed
    // Jump Height
    public override void OnMovementCancelled(InputAction.CallbackContext ctx)
    {

    }

    public override void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Vector2 MovementDirection = ctx.ReadValue<Vector2>();
        playerTransform.position += new Vector3(MovementDirection.x, MovementDirection.y, 0);
    }
}
