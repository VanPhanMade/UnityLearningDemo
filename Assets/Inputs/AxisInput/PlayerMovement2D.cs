using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : BaseLocomotion
{
    public override void OnMovementCancelled(InputAction.CallbackContext ctx)
    {
        Debug.Log("Stopped moving");
    }

    public override void OnMovementPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Moving");
        Vector2 MovementDirection = ctx.ReadValue<Vector2>();
        playerTransform.position += new Vector3(MovementDirection.x, MovementDirection.y, 0);
    }
}
