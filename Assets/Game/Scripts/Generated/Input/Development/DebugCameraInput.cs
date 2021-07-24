// GENERATED AUTOMATICALLY FROM 'Assets/Game/Settings/Input/DebugCameraInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Kaigo.Generated.Input.Debug
{
    public class @DebugCameraInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DebugCameraInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DebugCameraInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""89684b78-b664-46a2-b0d8-6346b502902e"",
            ""actions"": [
                {
                    ""name"": ""SwitchCamera"",
                    ""type"": ""Button"",
                    ""id"": ""4da73679-7645-45cc-af19-17658b90567c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0214dea-ff27-4aa8-ba9a-299c18cef2b1"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCamera"",
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
            m_Game_SwitchCamera = m_Game.FindAction("SwitchCamera", throwIfNotFound: true);
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
        private readonly InputAction m_Game_SwitchCamera;
        public struct GameActions
        {
            private @DebugCameraInput m_Wrapper;
            public GameActions(@DebugCameraInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @SwitchCamera => m_Wrapper.m_Game_SwitchCamera;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @SwitchCamera.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchCamera;
                    @SwitchCamera.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchCamera;
                    @SwitchCamera.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchCamera;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SwitchCamera.started += instance.OnSwitchCamera;
                    @SwitchCamera.performed += instance.OnSwitchCamera;
                    @SwitchCamera.canceled += instance.OnSwitchCamera;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnSwitchCamera(InputAction.CallbackContext context);
        }
    }
}
