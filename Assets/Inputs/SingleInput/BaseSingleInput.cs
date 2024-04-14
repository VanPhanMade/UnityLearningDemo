using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseSingleInput : MonoBehaviour
{
    public abstract void OnActionPerformed(InputAction.CallbackContext ctx);
    public abstract void OnActionCancelled(InputAction.CallbackContext ctx);
}
