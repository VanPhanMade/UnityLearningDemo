using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeleeDemo
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private Animator AbilityAnimator;
        [SerializeField] private LayerMask Layer;
        #region Unity
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                AbilityAnimator.Play("MeleeAttack", 0);
            }
        }
        #endregion

        #region MeleeAttack
        void Attack()
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * 20, Color.red, 5);
            // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            if (Physics.Raycast(transform.position, transform.position + transform.forward, out RaycastHit HitData, 20))
            {

                IDamageable Target = HitData.collider.GetComponent<IDamageable>();
                if (Target != null)
                {
                    Target.TakeDamage(20);
                }

            }
            else
            {
                //https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html
                if (Physics.SphereCast(transform.position, 1, transform.position + transform.forward, out RaycastHit HitDataSphere, 20, Layer, QueryTriggerInteraction.UseGlobal))
                {
                    IDamageable Target = HitDataSphere.transform.gameObject.GetComponent<IDamageable>();
                    if (Target != null)
                    {
                        Target.TakeDamage(20);
                    }
                }
            }

            

            
        }
        #endregion

    }
}

