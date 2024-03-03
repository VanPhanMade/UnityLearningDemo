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
                case TypeToggle.CSHARP_SYNTAX:
                    CSHARP_SYNTAX cSharpSyntax = new();
                    break;
                case TypeToggle.ABSTRACTCLASSES: // Also covers inheritance
                    AbstractClassDemo abstractClassDemo = new();
                    break;
                case TypeToggle.STACK_HEAP_STATIC_VALUES:
                    Stack_Heap_Static_ValuesDemo stack_Heap_Static_ValuesDemo = new();
                    break;

                default:
                    Debug.Log("Missing a case");
                    break;
            }

            
        }

    }
}

