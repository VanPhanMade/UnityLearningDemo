using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Monobehaviours.AttackFunctionality
{
    public class AttackFunctionality : MonoBehaviour
    {
        #region Field
        private event Action<int, int, int> AttackEvent;
        #endregion

        private void Awake()
        {
            AttackEvent += Attack;
            // Another thing to add here
        }

        void Start()
        {
            AttackEvent.Invoke(3, 17, 12);
        }

        void Update()
        {

        }

        void Attack(int a, int b, int c)
        {
            Debug.Log($"Triple: {a} {b} {c}");
        }

        // Make another function like attack


    }
}

