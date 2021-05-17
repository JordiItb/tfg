// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""d27ccdc4-9d1c-405a-9a46-59802c1051e3"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""93f10a50-5bb3-4d42-8054-d56f9e735680"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5c463bde-7159-44f3-9e6d-371934cb9bd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Running"",
                    ""type"": ""PassThrough"",
                    ""id"": ""32b12d28-33ec-4687-a690-266f16d9539c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d2be6b0f-c820-40be-b285-e8a2023df63c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5c355db0-5fa8-4f42-ba10-2bf0b8735356"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""37503d36-4a10-4cc4-a848-ab9510a65662"",
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
                    ""id"": ""1071e254-f4e0-4016-bac2-e35c50cdfa87"",
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
                    ""id"": ""79f47877-753c-454a-864b-19fe71976af3"",
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
                    ""id"": ""8899b334-7790-40b3-9f69-31d79a47e6c9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left Stick"",
                    ""id"": ""c3ff98eb-1762-4a7c-b011-633d643d9feb"",
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
                    ""id"": ""9dff6c9c-ea1e-40e7-b104-1596728f336b"",
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
                    ""id"": ""7cc62994-565c-4f30-bcd5-672446bef30a"",
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
                    ""id"": ""acaba00b-5a79-4643-9eeb-8bd87fc2321e"",
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
                    ""id"": ""c39f4eba-30ef-4a5b-8cf2-891a94a5b533"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""VR Controller"",
                    ""id"": ""fbe53987-18f7-4b61-9499-c022c70e70ed"",
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
                    ""id"": ""eb1f327f-facf-420d-afcb-d44ff105af4a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""381768ab-a063-47af-8126-1ee801355f72"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c44f8fc3-454c-47b8-8b27-524d6bea9c45"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""009bc3d2-d92d-4a65-b2b2-35cd7179fb44"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3a5d8be0-c263-4abf-b34e-95e39e98d7b4"",
                    ""path"": ""<XRSimulatedController>{LeftHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c52f058-1141-4e87-aa72-b4fc719d43c0"",
                    ""path"": ""<XRController>{LeftHand}/Primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Continuous Move"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65fdf992-a173-476d-8f4c-5876f456cc18"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Right Stick"",
                    ""id"": ""e8056bfd-efce-4ada-a5e2-91eeaf138cfd"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""657f4954-d556-4c6f-8eb6-723e4ba2d3ea"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e1ed89fd-ca3b-4277-ba11-314e96a00c2a"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2193c1ac-bf66-4dcd-b5c5-b0da5ab95e1f"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9dab29c5-4f39-4df8-acd4-7cc0d5c08859"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4157db3d-b38b-48ac-a0ef-95fb36fc17d2"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d956305-27ee-4a54-8647-af64a6f657cf"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Running"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""276da0d9-ba78-4fe9-8172-e4fcb588f6fe"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a20aa985-57c2-4b8e-9be5-96917cab841e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Habilities"",
            ""id"": ""fed4b7bd-ebf3-4066-8e83-6fe636aca071"",
            ""actions"": [
                {
                    ""name"": ""Zoom"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3dd45d18-efb2-4e67-9de9-a27eb989bf0a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Wave"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ebe2d9e-6b27-46ac-9723-bcef03dc5b7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Teleport"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3db296b6-ab79-4d3f-b3d6-593f57e55259"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d75ac0ff-1cf6-4e81-b7c5-74a12226dedc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Concentrate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""edea6586-2508-4ae4-a2a9-6072f3b45ee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea86a680-1050-43a5-a210-f6329ea4f471"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Concentrate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd654a06-88b8-47c9-8e7a-8f412920bc7d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Concentrate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71c0d6f7-ba6e-4705-a23b-3562ef51a7fb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dd15a57-ac99-4015-b654-0d5404282873"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15d03c36-4e4b-4f68-a91a-174834418c57"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daf05087-b2c3-4945-8f95-b33618227af7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Teleport"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e32eec47-09d7-4435-bc84-2a77af0e7fd7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b70188ef-4913-4100-889a-a03ae33fb182"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Wave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""340de614-d41b-4714-8a76-4c2b3b6976aa"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug Actions"",
            ""id"": ""9d3fc9be-fcb9-455e-b956-70dbf3daf4ab"",
            ""actions"": [
                {
                    ""name"": ""Scene 1"",
                    ""type"": ""Button"",
                    ""id"": ""b9d1d7fe-bff9-4a12-80a3-42c94a328f27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Scene 2"",
                    ""type"": ""Button"",
                    ""id"": ""9385b797-ee73-4923-9d46-2d5916980adf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72446b2a-4c59-4bce-80e8-b6578c44be64"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba5044d6-666c-4eef-9084-5c8232274711"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scene 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        m_PlayerMovement_Running = m_PlayerMovement.FindAction("Running", throwIfNotFound: true);
        m_PlayerMovement_Crouch = m_PlayerMovement.FindAction("Crouch", throwIfNotFound: true);
        // Player Habilities
        m_PlayerHabilities = asset.FindActionMap("Player Habilities", throwIfNotFound: true);
        m_PlayerHabilities_Zoom = m_PlayerHabilities.FindAction("Zoom", throwIfNotFound: true);
        m_PlayerHabilities_Wave = m_PlayerHabilities.FindAction("Wave", throwIfNotFound: true);
        m_PlayerHabilities_Teleport = m_PlayerHabilities.FindAction("Teleport", throwIfNotFound: true);
        m_PlayerHabilities_Grab = m_PlayerHabilities.FindAction("Grab", throwIfNotFound: true);
        m_PlayerHabilities_Concentrate = m_PlayerHabilities.FindAction("Concentrate", throwIfNotFound: true);
        // Debug Actions
        m_DebugActions = asset.FindActionMap("Debug Actions", throwIfNotFound: true);
        m_DebugActions_Scene1 = m_DebugActions.FindAction("Scene 1", throwIfNotFound: true);
        m_DebugActions_Scene2 = m_DebugActions.FindAction("Scene 2", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    private readonly InputAction m_PlayerMovement_Running;
    private readonly InputAction m_PlayerMovement_Crouch;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputAction @Running => m_Wrapper.m_PlayerMovement_Running;
        public InputAction @Crouch => m_Wrapper.m_PlayerMovement_Crouch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Running.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Running.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Running.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnRunning;
                @Crouch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCrouch;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Running.started += instance.OnRunning;
                @Running.performed += instance.OnRunning;
                @Running.canceled += instance.OnRunning;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Habilities
    private readonly InputActionMap m_PlayerHabilities;
    private IPlayerHabilitiesActions m_PlayerHabilitiesActionsCallbackInterface;
    private readonly InputAction m_PlayerHabilities_Zoom;
    private readonly InputAction m_PlayerHabilities_Wave;
    private readonly InputAction m_PlayerHabilities_Teleport;
    private readonly InputAction m_PlayerHabilities_Grab;
    private readonly InputAction m_PlayerHabilities_Concentrate;
    public struct PlayerHabilitiesActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerHabilitiesActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Zoom => m_Wrapper.m_PlayerHabilities_Zoom;
        public InputAction @Wave => m_Wrapper.m_PlayerHabilities_Wave;
        public InputAction @Teleport => m_Wrapper.m_PlayerHabilities_Teleport;
        public InputAction @Grab => m_Wrapper.m_PlayerHabilities_Grab;
        public InputAction @Concentrate => m_Wrapper.m_PlayerHabilities_Concentrate;
        public InputActionMap Get() { return m_Wrapper.m_PlayerHabilities; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerHabilitiesActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerHabilitiesActions instance)
        {
            if (m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface != null)
            {
                @Zoom.started -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnZoom;
                @Wave.started -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnWave;
                @Wave.performed -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnWave;
                @Wave.canceled -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnWave;
                @Teleport.started -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnTeleport;
                @Teleport.performed -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnTeleport;
                @Teleport.canceled -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnTeleport;
                @Grab.started -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnGrab;
                @Concentrate.started -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnConcentrate;
                @Concentrate.performed -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnConcentrate;
                @Concentrate.canceled -= m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface.OnConcentrate;
            }
            m_Wrapper.m_PlayerHabilitiesActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @Wave.started += instance.OnWave;
                @Wave.performed += instance.OnWave;
                @Wave.canceled += instance.OnWave;
                @Teleport.started += instance.OnTeleport;
                @Teleport.performed += instance.OnTeleport;
                @Teleport.canceled += instance.OnTeleport;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Concentrate.started += instance.OnConcentrate;
                @Concentrate.performed += instance.OnConcentrate;
                @Concentrate.canceled += instance.OnConcentrate;
            }
        }
    }
    public PlayerHabilitiesActions @PlayerHabilities => new PlayerHabilitiesActions(this);

    // Debug Actions
    private readonly InputActionMap m_DebugActions;
    private IDebugActionsActions m_DebugActionsActionsCallbackInterface;
    private readonly InputAction m_DebugActions_Scene1;
    private readonly InputAction m_DebugActions_Scene2;
    public struct DebugActionsActions
    {
        private @PlayerControls m_Wrapper;
        public DebugActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scene1 => m_Wrapper.m_DebugActions_Scene1;
        public InputAction @Scene2 => m_Wrapper.m_DebugActions_Scene2;
        public InputActionMap Get() { return m_Wrapper.m_DebugActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActionsActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActionsActions instance)
        {
            if (m_Wrapper.m_DebugActionsActionsCallbackInterface != null)
            {
                @Scene1.started -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene1;
                @Scene1.performed -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene1;
                @Scene1.canceled -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene1;
                @Scene2.started -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene2;
                @Scene2.performed -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene2;
                @Scene2.canceled -= m_Wrapper.m_DebugActionsActionsCallbackInterface.OnScene2;
            }
            m_Wrapper.m_DebugActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scene1.started += instance.OnScene1;
                @Scene1.performed += instance.OnScene1;
                @Scene1.canceled += instance.OnScene1;
                @Scene2.started += instance.OnScene2;
                @Scene2.performed += instance.OnScene2;
                @Scene2.canceled += instance.OnScene2;
            }
        }
    }
    public DebugActionsActions @DebugActions => new DebugActionsActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnRunning(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IPlayerHabilitiesActions
    {
        void OnZoom(InputAction.CallbackContext context);
        void OnWave(InputAction.CallbackContext context);
        void OnTeleport(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnConcentrate(InputAction.CallbackContext context);
    }
    public interface IDebugActionsActions
    {
        void OnScene1(InputAction.CallbackContext context);
        void OnScene2(InputAction.CallbackContext context);
    }
}
