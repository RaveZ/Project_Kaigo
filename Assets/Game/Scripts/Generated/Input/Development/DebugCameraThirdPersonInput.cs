// GENERATED AUTOMATICALLY FROM 'Assets/Game/Settings/Input/DebugCameraThirdPersonInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Kaigo.Generated.Input.Debug
{
    public class @DebugCameraThirdPersonInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DebugCameraThirdPersonInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugCameraThirdPersonInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""278132ae-0c5e-42ea-b5c1-4e6b741c6e0a"",
            ""actions"": [
                {
                    ""name"": ""CancelLook"",
                    ""type"": ""Button"",
                    ""id"": ""18191072-59b9-4466-85de-84488a986fbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a181ea24-a10a-4bf4-86b1-bd3fffd1a42b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_CancelLook = m_Game.FindAction("CancelLook", throwIfNotFound: true);
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

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_CancelLook;
        public struct GameActions
        {
            private @DebugCameraThirdPersonInput m_Wrapper;
            public GameActions(@DebugCameraThirdPersonInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @CancelLook => m_Wrapper.m_Game_CancelLook;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @CancelLook.started -= m_Wrapper.m_GameActionsCallbackInterface.OnCancelLook;
                    @CancelLook.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnCancelLook;
                    @CancelLook.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnCancelLook;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CancelLook.started += instance.OnCancelLook;
                    @CancelLook.performed += instance.OnCancelLook;
                    @CancelLook.canceled += instance.OnCancelLook;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnCancelLook(InputAction.CallbackContext context);
        }
    }
}
