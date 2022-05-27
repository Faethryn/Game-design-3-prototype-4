// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9538db47-8a66-4ac6-ad78-1b4049ca3858"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""f2b4c6f1-7075-41b4-8ead-dc5c37b0215e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""70f43403-ec18-4faf-aaf0-53a4c9921a74"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Item"",
                    ""type"": ""Button"",
                    ""id"": ""9620dac9-184a-415e-b10b-3892b6fcb609"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""37397dc7-3d2c-4d21-b6ec-31cf0847b4ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousItem"",
                    ""type"": ""Button"",
                    ""id"": ""4bfd1471-fed1-4945-bed6-174ab89acf39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""af439e6d-f5e0-4ca1-90a2-40554ad6020c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1)""
                },
                {
                    ""name"": ""NextLevel"",
                    ""type"": ""Button"",
                    ""id"": ""ed7a5223-60af-4677-a921-a6fc1e421e91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Gasoline"",
                    ""type"": ""Value"",
                    ""id"": ""a4c69e3e-eefb-4903-8d5e-c20cec93fcf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89d47e68-f354-4761-b63f-5a90bd9c88d1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82fc31f1-e66f-4221-8489-f60094e90d9d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65923508-40eb-46c7-80e0-925bfbc5c769"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af78892c-cac3-43d0-b1dd-764ae4d5cee7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fed056d9-79b6-4b96-8a45-78a181cb132c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8730818-27bb-464a-8312-44ded1931fce"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18ce3029-aa36-4199-b5c9-b56322610185"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use Gasoline"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""186eea50-9368-48e9-b371-7b30f2de33b9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox controller"",
            ""bindingGroup"": ""Xbox controller"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_UseItem = m_Player.FindAction("Use Item", throwIfNotFound: true);
        m_Player_NextItem = m_Player.FindAction("NextItem", throwIfNotFound: true);
        m_Player_PreviousItem = m_Player.FindAction("PreviousItem", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_NextLevel = m_Player.FindAction("NextLevel", throwIfNotFound: true);
        m_Player_UseGasoline = m_Player.FindAction("Use Gasoline", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_UseItem;
    private readonly InputAction m_Player_NextItem;
    private readonly InputAction m_Player_PreviousItem;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_NextLevel;
    private readonly InputAction m_Player_UseGasoline;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @UseItem => m_Wrapper.m_Player_UseItem;
        public InputAction @NextItem => m_Wrapper.m_Player_NextItem;
        public InputAction @PreviousItem => m_Wrapper.m_Player_PreviousItem;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @NextLevel => m_Wrapper.m_Player_NextLevel;
        public InputAction @UseGasoline => m_Wrapper.m_Player_UseGasoline;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @UseItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseItem;
                @NextItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @NextItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @NextItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @PreviousItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviousItem;
                @PreviousItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviousItem;
                @PreviousItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPreviousItem;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @NextLevel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextLevel;
                @NextLevel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextLevel;
                @NextLevel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextLevel;
                @UseGasoline.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseGasoline;
                @UseGasoline.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseGasoline;
                @UseGasoline.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseGasoline;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @PreviousItem.started += instance.OnPreviousItem;
                @PreviousItem.performed += instance.OnPreviousItem;
                @PreviousItem.canceled += instance.OnPreviousItem;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @NextLevel.started += instance.OnNextLevel;
                @NextLevel.performed += instance.OnNextLevel;
                @NextLevel.canceled += instance.OnNextLevel;
                @UseGasoline.started += instance.OnUseGasoline;
                @UseGasoline.performed += instance.OnUseGasoline;
                @UseGasoline.canceled += instance.OnUseGasoline;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_XboxcontrollerSchemeIndex = -1;
    public InputControlScheme XboxcontrollerScheme
    {
        get
        {
            if (m_XboxcontrollerSchemeIndex == -1) m_XboxcontrollerSchemeIndex = asset.FindControlSchemeIndex("Xbox controller");
            return asset.controlSchemes[m_XboxcontrollerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnNextItem(InputAction.CallbackContext context);
        void OnPreviousItem(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnNextLevel(InputAction.CallbackContext context);
        void OnUseGasoline(InputAction.CallbackContext context);
    }
}
