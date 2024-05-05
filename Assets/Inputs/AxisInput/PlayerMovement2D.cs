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

        Debug.DrawLine(playerTransform.position, playerTransform.position + playerTransform.forward * 10, Color.red, 1);
        Debug.DrawLine(playerTransform.position, playerTransform.position + playerTransform.up * 10, Color.green, 1);
        Debug.DrawLine(playerTransform.position, playerTransform.position + playerTransform.right * 10, Color.blue, 1);
        playerTransform.rotation = Quaternion.LookRotation(new Vector3(MovementDirection.x, MovementDirection.y, 0), new Vector3(0, 0, -1));

        Debug.DrawLine(playerTransform.position, playerTransform.position + new Vector3(MovementDirection.x, MovementDirection.y, 0) * 15, Color.magenta, 1);
    }
}
