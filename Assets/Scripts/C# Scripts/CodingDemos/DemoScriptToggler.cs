using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CodingDemo
{
    enum TypeToggle
    {
        NONE,
        EVENTS,
        INTERFACES,
        INHERITENCE,
        CLASSES_FUNCTIONS,
        ABSTRACTCLASSES,
        ENUMS,
        STACK_HEAP_STATIC_VALUES,
        CSHARP_SYNTAX
    }
    public class DemoScriptToggler : MonoBehaviour
    {
        [SerializeField] private TypeToggle TypeToggle;
        private void Start()
        {
            switch (TypeToggle)
            {
                case TypeToggle.NONE:
                    Debug.Log("None selected?");
                    break;
                case TypeToggle.EVENTS:
                    EventDemo eventsDemo = new();
                    break;
                case TypeToggle.INTERFACES:
                    InterfaceDemo interfaceDemo = new();
                    break;
                case TypeToggle.INHERITENCE:
                    break;
                case TypeToggle.CSHARP_SYNTAX:
                    CSHARP_SYNTAX cSharpSyntax = new();
                    break;

                default:
                    Debug.Log("Missing a case");
                    break;
            }
        }

    }
}

