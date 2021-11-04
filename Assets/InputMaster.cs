// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cf3d59b8-bf11-4654-8a96-7788130d439c"",
            ""actions"": [
                {
                    ""name"": ""ClickDowm"",
                    ""type"": ""Button"",
                    ""id"": ""78244406-77f7-423c-afa6-146b899523e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ClickUp"",
                    ""type"": ""Button"",
                    ""id"": ""7a2a76b8-1bfc-4bdb-b317-78097e968f81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""a2a940ae-1b37-46d0-aac7-d76cd7aab12b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3159ca80-faea-4bf5-b11f-8e92a7ebbeef"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickDowm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8520897-ba22-448b-98af-ed34a6c734cf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68f114c8-a67b-4a5c-9db9-28292163e369"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ClickDowm = m_Player.FindAction("ClickDowm", throwIfNotFound: true);
        m_Player_ClickUp = m_Player.FindAction("ClickUp", throwIfNotFound: true);
        m_Player_MousePosition = m_Player.FindAction("MousePosition", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ClickDowm;
    private readonly InputAction m_Player_ClickUp;
    private readonly InputAction m_Player_MousePosition;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickDowm => m_Wrapper.m_Player_ClickDowm;
        public InputAction @ClickUp => m_Wrapper.m_Player_ClickUp;
        public InputAction @MousePosition => m_Wrapper.m_Player_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ClickDowm.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDowm;
                @ClickDowm.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDowm;
                @ClickDowm.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickDowm;
                @ClickUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @ClickUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @ClickUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickUp;
                @MousePosition.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickDowm.started += instance.OnClickDowm;
                @ClickDowm.performed += instance.OnClickDowm;
                @ClickDowm.canceled += instance.OnClickDowm;
                @ClickUp.started += instance.OnClickUp;
                @ClickUp.performed += instance.OnClickUp;
                @ClickUp.canceled += instance.OnClickUp;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnClickDowm(InputAction.CallbackContext context);
        void OnClickUp(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
