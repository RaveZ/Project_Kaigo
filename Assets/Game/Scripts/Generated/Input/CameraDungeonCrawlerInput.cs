// GENERATED AUTOMATICALLY FROM 'Assets/Game/Settings/Input/CameraDungeonCrawlerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Kaigo.Generated.Input
{
    public class @CameraDungeonCrawlerInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CameraDungeonCrawlerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CameraDungeonCrawlerInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""82abb964-d43f-4b3f-af5d-f782455326cc"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""01ab9fa0-c3f6-4cc0-be77-e237ece23aa8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnableAltRotation"",
                    ""type"": ""Button"",
                    ""id"": ""2e9fedb9-acc6-4a14-92d0-4047f75a9ae1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltRotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""61b5b92a-2cf1-43e9-a543-45a14ebb346a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrow"",
                    ""id"": ""b42289bb-4f87-42b4-b469-a5fb9829f16d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b7d18039-fa77-4dff-87cb-1463b83f0041"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""06bf7d99-af3a-4d81-aa9b-0d350aa51ed6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81454d1b-1475-47ce-a21a-9993e341b4eb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ffa84cf8-b313-4db0-9484-4f4c0a89d817"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""40da9630-3050-4220-a5f9-0b45b850f2dc"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8fd5c913-e9cc-4912-8f63-7ee855adf2b7"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9808f6e5-2f45-46c7-adbc-ab82b2c66f09"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7aebd440-8067-4a17-b8d3-7271e5e53bb2"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fd144d20-adcf-43f1-a1e7-d0af566ed38c"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""25666c3c-c59d-495f-83ea-bf90355c9c00"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12dcae12-924a-441f-a70c-99bb2337e8a5"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnableAltRotation"",
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
            m_Game_Rotation = m_Game.FindAction("Rotation", throwIfNotFound: true);
            m_Game_EnableAltRotation = m_Game.FindAction("EnableAltRotation", throwIfNotFound: true);
            m_Game_AltRotation = m_Game.FindAction("AltRotation", throwIfNotFound: true);
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
        private readonly InputAction m_Game_Rotation;
        private readonly InputAction m_Game_EnableAltRotation;
        private readonly InputAction m_Game_AltRotation;
        public struct GameActions
        {
            private @CameraDungeonCrawlerInput m_Wrapper;
            public GameActions(@CameraDungeonCrawlerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_Game_Rotation;
            public InputAction @EnableAltRotation => m_Wrapper.m_Game_EnableAltRotation;
            public InputAction @AltRotation => m_Wrapper.m_Game_AltRotation;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRotation;
                    @EnableAltRotation.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEnableAltRotation;
                    @EnableAltRotation.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEnableAltRotation;
                    @EnableAltRotation.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEnableAltRotation;
                    @AltRotation.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAltRotation;
                    @AltRotation.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAltRotation;
                    @AltRotation.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAltRotation;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                    @EnableAltRotation.started += instance.OnEnableAltRotation;
                    @EnableAltRotation.performed += instance.OnEnableAltRotation;
                    @EnableAltRotation.canceled += instance.OnEnableAltRotation;
                    @AltRotation.started += instance.OnAltRotation;
                    @AltRotation.performed += instance.OnAltRotation;
                    @AltRotation.canceled += instance.OnAltRotation;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IGameActions
        {
            void OnRotation(InputAction.CallbackContext context);
            void OnEnableAltRotation(InputAction.CallbackContext context);
            void OnAltRotation(InputAction.CallbackContext context);
        }
    }
}
