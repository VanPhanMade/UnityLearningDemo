using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeleeDemo
{
    public class TargetDummy : MonoBehaviour, IDamageable
    {
        public void TakeDamage(float Damage)
        {
            Debug.Log($"Ow you did {Damage} damage");
        }
    }

    public interface IDamageable
    {
        public void TakeDamage(float Damage);
    }
}

