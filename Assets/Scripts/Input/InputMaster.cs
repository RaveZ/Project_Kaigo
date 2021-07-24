// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputMaster.inputactions'

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
            ""id"": ""c0d10474-c357-4246-86eb-00e62b6dbda8"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""875109b6-7157-4330-9f06-9ac83cfd6437"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""movement"",
                    ""type"": ""Button"",
                    ""id"": ""14b411ce-ed51-4c20-a1a5-52864a1a879f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""0e76ee26-4b81-415c-8d59-909e7e22c8f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47b5028d-e2d7-42ed-80d1-b8e00ae070b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Axis"",
                    ""id"": ""2f4ded17-8cee-486d-8e43-f744001fee6d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fb9ddafc-0b02-4486-bae6-8b0bc0885377"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3ae06b50-2273-48dd-adba-9ffc2d5a2d7c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""513097fa-c028-4798-a6b6-3c6030f2abd1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2578be81-cd6a-4016-9758-558001cae106"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a4e7adea-896e-4cae-a4b2-efe1547b9c4b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""1ceb0033-3970-4cad-abeb-13d3967b61e1"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6c429a98-13bd-41b0-8d45-5f10411e5755"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d6d7f26-d9e8-4017-97ec-477ff8af8360"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GamePlay"",
            ""id"": ""f654a50f-b50c-4dad-92a9-5ef33adab077"",
            ""actions"": [
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Button"",
                    ""id"": ""781c4751-59b6-484a-b021-a9627d7ed085"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""defense"",
                    ""type"": ""Button"",
                    ""id"": ""a9253af2-d2ed-4da5-919f-a42b457b6858"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""4f2a04dc-2742-4824-b52c-6631a8c4856f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOnNextTarget"",
                    ""type"": ""Button"",
                    ""id"": ""5e83ffa0-050f-434f-ac3e-ca8af8b13968"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26591d94-58db-4c85-8bf7-0e0e12be2e4e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1968b644-2d15-4040-8fd8-02b94e747ae6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""defense"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca0e2e34-33e0-4bd8-b617-d647a2d49f0a"",
                    ""path"": ""<Mouse>/backButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5846fdb-90a7-4eaf-a88c-1ee570aca8b3"",
                    ""path"": ""<Mouse>/forwardButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard n Mouse"",
                    ""action"": ""LockOnNextTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard n Mouse"",
            ""bindingGroup"": ""Keyboard n Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_movement = m_Player.FindAction("movement", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MouseLook = m_Mouse.FindAction("MouseLook", throwIfNotFound: true);
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_BasicAttack = m_GamePlay.FindAction("BasicAttack", throwIfNotFound: true);
        m_GamePlay_defense = m_GamePlay.FindAction("defense", throwIfNotFound: true);
        m_GamePlay_LockOn = m_GamePlay.FindAction("LockOn", throwIfNotFound: true);
        m_GamePlay_LockOnNextTarget = m_GamePlay.FindAction("LockOnNextTarget", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_movement;
    private readonly InputAction m_Player_Sprint;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @movement => m_Wrapper.m_Player_movement;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MouseLook;
    public struct MouseActions
    {
        private @InputMaster m_Wrapper;
        public MouseActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLook => m_Wrapper.m_Mouse_MouseLook;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MouseLook.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                @MouseLook.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                @MouseLook.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLook.started += instance.OnMouseLook;
                @MouseLook.performed += instance.OnMouseLook;
                @MouseLook.canceled += instance.OnMouseLook;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_BasicAttack;
    private readonly InputAction m_GamePlay_defense;
    private readonly InputAction m_GamePlay_LockOn;
    private readonly InputAction m_GamePlay_LockOnNextTarget;
    public struct GamePlayActions
    {
        private @InputMaster m_Wrapper;
        public GamePlayActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @BasicAttack => m_Wrapper.m_GamePlay_BasicAttack;
        public InputAction @defense => m_Wrapper.m_GamePlay_defense;
        public InputAction @LockOn => m_Wrapper.m_GamePlay_LockOn;
        public InputAction @LockOnNextTarget => m_Wrapper.m_GamePlay_LockOnNextTarget;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @BasicAttack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnBasicAttack;
                @defense.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDefense;
                @defense.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDefense;
                @defense.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnDefense;
                @LockOn.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOn;
                @LockOnNextTarget.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOnNextTarget;
                @LockOnNextTarget.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOnNextTarget;
                @LockOnNextTarget.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLockOnNextTarget;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @BasicAttack.started += instance.OnBasicAttack;
                @BasicAttack.performed += instance.OnBasicAttack;
                @BasicAttack.canceled += instance.OnBasicAttack;
                @defense.started += instance.OnDefense;
                @defense.performed += instance.OnDefense;
                @defense.canceled += instance.OnDefense;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @LockOnNextTarget.started += instance.OnLockOnNextTarget;
                @LockOnNextTarget.performed += instance.OnLockOnNextTarget;
                @LockOnNextTarget.canceled += instance.OnLockOnNextTarget;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_KeyboardnMouseSchemeIndex = -1;
    public InputControlScheme KeyboardnMouseScheme
    {
        get
        {
            if (m_KeyboardnMouseSchemeIndex == -1) m_KeyboardnMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard n Mouse");
            return asset.controlSchemes[m_KeyboardnMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnMouseLook(InputAction.CallbackContext context);
    }
    public interface IGamePlayActions
    {
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnDefense(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnLockOnNextTarget(InputAction.CallbackContext context);
    }
}
