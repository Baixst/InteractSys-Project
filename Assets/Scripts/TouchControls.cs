// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/TouchControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControls"",
    ""maps"": [
        {
            ""name"": ""Default Controls"",
            ""id"": ""451dad0d-6e53-4cad-bd99-8ca35ecf90fa"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5a31c89f-4c4f-4033-9518-0dd3051eea54"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""c5814a3b-108a-4252-838c-d4d07398f028"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""532879d7-54d1-48aa-8807-d666f1f8f509"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd0bee99-1ef6-46b1-a70a-8541cbf4c9fb"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default Controls
        m_DefaultControls = asset.FindActionMap("Default Controls", throwIfNotFound: true);
        m_DefaultControls_TouchPosition = m_DefaultControls.FindAction("TouchPosition", throwIfNotFound: true);
        m_DefaultControls_TouchPress = m_DefaultControls.FindAction("TouchPress", throwIfNotFound: true);
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

    // Default Controls
    private readonly InputActionMap m_DefaultControls;
    private IDefaultControlsActions m_DefaultControlsActionsCallbackInterface;
    private readonly InputAction m_DefaultControls_TouchPosition;
    private readonly InputAction m_DefaultControls_TouchPress;
    public struct DefaultControlsActions
    {
        private @TouchControls m_Wrapper;
        public DefaultControlsActions(@TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_DefaultControls_TouchPosition;
        public InputAction @TouchPress => m_Wrapper.m_DefaultControls_TouchPress;
        public InputActionMap Get() { return m_Wrapper.m_DefaultControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultControlsActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultControlsActions instance)
        {
            if (m_Wrapper.m_DefaultControlsActionsCallbackInterface != null)
            {
                @TouchPosition.started -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPosition;
                @TouchPress.started -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.performed -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPress;
                @TouchPress.canceled -= m_Wrapper.m_DefaultControlsActionsCallbackInterface.OnTouchPress;
            }
            m_Wrapper.m_DefaultControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }
        }
    }
    public DefaultControlsActions @DefaultControls => new DefaultControlsActions(this);
    public interface IDefaultControlsActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
    }
}
