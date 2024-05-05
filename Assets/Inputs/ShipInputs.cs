//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Inputs/ShipInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ShipInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ShipInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ShipInputs"",
    ""maps"": [
        {
            ""name"": ""ShipThing"",
            ""id"": ""fd0b765b-fa08-4bd6-91f2-5737217b82b3"",
            ""actions"": [
                {
                    ""name"": ""Combo"",
                    ""type"": ""Value"",
                    ""id"": ""4244efd0-537f-4fd9-b24c-8458416fdd2d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f7d9f719-b34e-4fa7-8c8d-f6feac61687e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8eb1ab80-05ee-47bb-995b-a61a66636e53"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1239ef40-060b-4d97-b40e-adb0c5c21d75"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""588216d3-da8d-4d1a-a12e-28174f431eeb"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Combo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShipThing
        m_ShipThing = asset.FindActionMap("ShipThing", throwIfNotFound: true);
        m_ShipThing_Combo = m_ShipThing.FindAction("Combo", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ShipThing
    private readonly InputActionMap m_ShipThing;
    private List<IShipThingActions> m_ShipThingActionsCallbackInterfaces = new List<IShipThingActions>();
    private readonly InputAction m_ShipThing_Combo;
    public struct ShipThingActions
    {
        private @ShipInputs m_Wrapper;
        public ShipThingActions(@ShipInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Combo => m_Wrapper.m_ShipThing_Combo;
        public InputActionMap Get() { return m_Wrapper.m_ShipThing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipThingActions set) { return set.Get(); }
        public void AddCallbacks(IShipThingActions instance)
        {
            if (instance == null || m_Wrapper.m_ShipThingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ShipThingActionsCallbackInterfaces.Add(instance);
            @Combo.started += instance.OnCombo;
            @Combo.performed += instance.OnCombo;
            @Combo.canceled += instance.OnCombo;
        }

        private void UnregisterCallbacks(IShipThingActions instance)
        {
            @Combo.started -= instance.OnCombo;
            @Combo.performed -= instance.OnCombo;
            @Combo.canceled -= instance.OnCombo;
        }

        public void RemoveCallbacks(IShipThingActions instance)
        {
            if (m_Wrapper.m_ShipThingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IShipThingActions instance)
        {
            foreach (var item in m_Wrapper.m_ShipThingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ShipThingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ShipThingActions @ShipThing => new ShipThingActions(this);
    public interface IShipThingActions
    {
        void OnCombo(InputAction.CallbackContext context);
    }
}
