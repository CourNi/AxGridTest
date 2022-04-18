// GENERATED AUTOMATICALLY FROM 'Assets/Control/MainControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControl"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""d294159a-2041-402d-8936-c706d44a3e20"",
            ""actions"": [
                {
                    ""name"": ""Console"",
                    ""type"": ""Button"",
                    ""id"": ""141fbe72-b4ef-4ef8-a7f9-305631405a30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return"",
                    ""type"": ""Button"",
                    ""id"": ""d9623575-8ebb-470b-be21-b08f02343245"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3dd4722d-c7d1-4b69-8d59-14acc57cc57c"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cebbad6-c860-44e0-a2f5-8b40ad1ff517"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Return"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Console = m_Main.FindAction("Console", throwIfNotFound: true);
        m_Main_Return = m_Main.FindAction("Return", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Console;
    private readonly InputAction m_Main_Return;
    public struct MainActions
    {
        private @MainControl m_Wrapper;
        public MainActions(@MainControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Console => m_Wrapper.m_Main_Console;
        public InputAction @Return => m_Wrapper.m_Main_Return;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Console.started -= m_Wrapper.m_MainActionsCallbackInterface.OnConsole;
                @Console.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnConsole;
                @Console.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnConsole;
                @Return.started -= m_Wrapper.m_MainActionsCallbackInterface.OnReturn;
                @Return.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnReturn;
                @Return.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnReturn;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Console.started += instance.OnConsole;
                @Console.performed += instance.OnConsole;
                @Console.canceled += instance.OnConsole;
                @Return.started += instance.OnReturn;
                @Return.performed += instance.OnReturn;
                @Return.canceled += instance.OnReturn;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnConsole(InputAction.CallbackContext context);
        void OnReturn(InputAction.CallbackContext context);
    }
}
