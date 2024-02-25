using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeleeDemo
{
    public class TargetDummy : MonoBehaviour, IDamageable
    {
        void IDamageable.TakeDamage(float Damage)
        {
            Debug.Log($"Ow you did {Damage} damage");
        }
    }

    public interface IDamageable
    {
        void TakeDamage(float Damage);
    }
}

