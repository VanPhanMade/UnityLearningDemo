using UnityEngine;
using UnityEngine.InputSystem;

public class FireAttack : BaseSingleInput
{
    [SerializeField] GameObject projectile;
    public override void OnActionCancelled(InputAction.CallbackContext ctx)
    {
      
    }

    public override void OnActionPerformed(InputAction.CallbackContext ctx)
    {
        GameObject spawnedProjectile = Instantiate(projectile);
        spawnedProjectile.transform.position = playerTransform.position + new Vector3(AdvancedInputTutorial.CurrentDirectionInput.x, AdvancedInputTutorial.CurrentDirectionInput.y, 0);
        spawnedProjectile.transform.forward = new Vector3(AdvancedInputTutorial.CurrentDirectionInput.x, AdvancedInputTutorial.CurrentDirectionInput.y, 0);

        FireballProjectile fireballProjectile = spawnedProjectile.GetComponent<FireballProjectile>();
    }
}
