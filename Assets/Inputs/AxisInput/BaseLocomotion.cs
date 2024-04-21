using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public abstract void OnMovementPerformed(InputAction.CallbackContext ctx);
    public abstract void OnMovementCancelled(InputAction.CallbackContext ctx);
}
