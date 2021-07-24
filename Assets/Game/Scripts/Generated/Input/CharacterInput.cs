// GENERATED AUTOMATICALLY FROM 'Assets/Game/Settings/Input/CharacterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Kaigo.Generated.Input
{
    public class @CharacterInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CharacterInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""8fff7b3a-93a0-4e72-b824-ee49823d93ac"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""60c0d922-0683-4192-baaa-83ca4066e86c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""422973fa-3e63-44fe-9910-df9bb5c37ea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""32ce66f3-7863-4801-8c3d-055374fcb511"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""5aeb2e43-5ee9-438d-93bd-767a29057ddf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""90d60e65-f730-4a28-a0fc-654e51ba401f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""12c73709-4ed8-4f91-972d-5ff9de1b93a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""89c0bccd-871d-4be8-8770-0a0945c25069"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e75ce03b-def1-4c43-b6b0-18f4f16652ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7d4568bc-83c0-49cd-99b8-cd6bd5eb459d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStickGamepad"",
                    ""id"": ""865bde89-6dbf-46fc-8dfc-62bb0ec60519"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""15551731-ab3b-49fb-98a5-f906e1df7c15"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8d5d970f-f68f-4529-8222-39beea4a1849"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3f5b46d3-379f-431f-afb3-ed9e32f6c57f"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66ee5f15-627f-406c-90d7-4fea907d749c"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc8ff622-5f91-41b4-9c2f-dba0178543e0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d158ef03-e207-460d-8ffd-200eeabaa26e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6754653f-23be-4ca7-87a1-4836a03d3074"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""425c893a-7cef-430b-bbaa-eab89ae4530a"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""8d644a65-6b45-468c-9f87-dc11a52f3b85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d5b2c65-3aad-4789-a8d5-81ef42e9facb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
            m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
            m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
            m_Game_Attack = m_Game.FindAction("Attack", throwIfNotFound: true);
            m_Game_Sprint = m_Game.FindAction("Sprint", throwIfNotFound: true);
            // MainMenu
            m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
            m_MainMenu_Newaction = m_MainMenu.FindAction("New action", throwIfNotFound: true);
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
        private readonly InputAction m_Game_Movement;
        private readonly InputAction m_Game_Jump;
        private readonly InputAction m_Game_Attack;
        private readonly InputAction m_Game_Sprint;
        public struct GameActions
        {
            private @CharacterInput m_Wrapper;
            public GameActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Game_Movement;
            public InputAction @Jump => m_Wrapper.m_Game_Jump;
            public InputAction @Attack => m_Wrapper.m_Game_Attack;
            public InputAction @Sprint => m_Wrapper.m_Game_Sprint;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                    @Attack.started -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnAttack;
                    @Sprint.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSprint;
                    @Sprint.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSprint;
                    @Sprint.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSprint;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Sprint.started += instance.OnSprint;
                    @Sprint.performed += instance.OnSprint;
                    @Sprint.canceled += instance.OnSprint;
                }
            }
        }
        public GameActions @Game => new GameActions(this);

        // MainMenu
        private readonly InputActionMap m_MainMenu;
        private IMainMenuActions m_MainMenuActionsCallbackInterface;
        private readonly InputAction m_MainMenu_Newaction;
        public struct MainMenuActions
        {
            private @CharacterInput m_Wrapper;
            public MainMenuActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_MainMenu_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
            public void SetCallbacks(IMainMenuActions instance)
            {
                if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public MainMenuActions @MainMenu => new MainMenuActions(this);
        public interface IGameActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
        }
        public interface IMainMenuActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
