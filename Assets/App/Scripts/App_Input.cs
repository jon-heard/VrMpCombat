// GENERATED AUTOMATICALLY FROM 'Assets/App/App_Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @App_Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @App_Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""App_Input"",
    ""maps"": [
        {
            ""name"": ""Vr_Transforms"",
            ""id"": ""c07d24fa-7511-4f50-be35-b59bc59aade5"",
            ""actions"": [
                {
                    ""name"": ""Head_Position"",
                    ""type"": ""Value"",
                    ""id"": ""b0cc67c7-04cc-4856-9e10-612a3d43ee89"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Head_Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""4d3350da-4737-46f4-9716-fc2ae323858b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand_Left_Position"",
                    ""type"": ""Value"",
                    ""id"": ""82e05f90-f4d2-4db7-8076-95333fc5d1aa"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand_Left_Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""912d11fc-cee0-4320-8790-8e52f3a89d18"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand_Right_Position"",
                    ""type"": ""Value"",
                    ""id"": ""b22fbcbd-cfa2-480e-9f2a-1a4d95caed4a"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hand_Right_Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""cdb1b75c-de39-4d97-b3d1-aa07470a3bf6"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a72f70b0-a6e3-4842-b715-d0d9cb32d00b"",
                    ""path"": ""<XRHMD>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Head_Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d41e36f-9330-42db-8ea8-2c933055ee70"",
                    ""path"": ""<XRHMD>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Head_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""114376fa-1e3d-40d6-80d6-80f254c615e4"",
                    ""path"": ""<XRController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand_Left_Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fa47599-f2ab-4b88-9e80-fc2fa3fac2b9"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand_Left_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e01c87b2-6616-4b42-b648-5064ec9dcd98"",
                    ""path"": ""<XRController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand_Right_Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62297f00-f6ce-4d3c-87c8-4672bebd0b3c"",
                    ""path"": ""<XRController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand_Right_Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Controls"",
            ""id"": ""937cba72-ae89-4aca-8a20-48ef186c134c"",
            ""actions"": [
                {
                    ""name"": ""Look_NonVr"",
                    ""type"": ""Value"",
                    ""id"": ""660e0630-5ef9-440e-b021-4c95a7346298"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look_Vr"",
                    ""type"": ""Value"",
                    ""id"": ""a10942c5-3fc0-4e7d-977e-8c92acb8f133"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Vr"",
                    ""type"": ""Value"",
                    ""id"": ""188da42c-f424-462e-b841-3d9ea4c92136"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Forward"",
                    ""type"": ""Button"",
                    ""id"": ""86eedf7b-4c58-4585-ba47-7345d2bf3228"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Strafe_Right"",
                    ""type"": ""Button"",
                    ""id"": ""89e7f53b-c66d-4f7b-a03a-2c173b0ead04"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Backward"",
                    ""type"": ""Button"",
                    ""id"": ""36fda522-fa9f-4eac-9e4e-a1bdf08cabee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Strafe_Left"",
                    ""type"": ""Button"",
                    ""id"": ""421bbe6b-8da9-416b-a084-a88546226ad8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullArrow_Vr"",
                    ""type"": ""Button"",
                    ""id"": ""17aa075a-0912-45a4-b135-e90d4ed253f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullTeleportArrow_Vr"",
                    ""type"": ""Button"",
                    ""id"": ""7b117b33-6ddc-468e-8b4b-c46e09a496bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullArrow_NonVr"",
                    ""type"": ""Button"",
                    ""id"": ""2750d0e0-edd3-4080-b641-836097260f2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PullTeleportArrow_NonVr"",
                    ""type"": ""Button"",
                    ""id"": ""783f30d4-39c2-4c48-a33c-fde315783216"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseToggle"",
                    ""type"": ""Button"",
                    ""id"": ""c4230c7e-c5f2-4e33-a598-49a661353e9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseLookEnable"",
                    ""type"": ""Button"",
                    ""id"": ""51faf3a0-5bce-4b31-836a-24adac1d872f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cdadaf9c-459f-4c3e-b866-1b7d6a239e39"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""957985bb-585a-4869-bee6-5fca0192fe10"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62292788-6b34-4c4e-83e5-3792d79beb4f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look_NonVr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2a51509-71df-4036-a5b4-2ae34a85a32b"",
                    ""path"": ""<XRController>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Vr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d280422a-93f7-4ed6-a5cd-f48522a348aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseToggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""154587f9-eac6-41aa-9f30-64f7295a3259"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Strafe_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd9db355-af83-4021-9ae6-3fe09eb49561"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Strafe_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd22446f-9828-4068-9805-9dae194515ff"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Strafe_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5e36339-ccc0-47e9-945c-d47e07055ca4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Strafe_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58974400-6512-41cc-8bfb-fdb6f7b273c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1642f971-8b47-420c-94cc-db2fe966f29f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""702c7e8e-a0d8-40fa-9987-27b256d9e4b3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLookEnable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25af9202-b9bf-4310-b174-3b3e9bbe6ed7"",
                    ""path"": ""<XRController>{RightHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look_Vr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78a0d609-d794-416c-ae0a-8192749887ac"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullTeleportArrow_Vr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee8ea9f6-14d8-49f3-b2d9-3d9168bc686b"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullTeleportArrow_Vr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7741b84d-2adb-4822-a8cb-b8353ed71ff7"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullArrow_Vr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1218889-d9bd-4a75-a6e4-21a34e482550"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullArrow_NonVr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3d09841-a52e-4d5f-a926-a5b5f2fc15f0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullTeleportArrow_NonVr"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Vr_Transforms
        m_Vr_Transforms = asset.FindActionMap("Vr_Transforms", throwIfNotFound: true);
        m_Vr_Transforms_Head_Position = m_Vr_Transforms.FindAction("Head_Position", throwIfNotFound: true);
        m_Vr_Transforms_Head_Rotation = m_Vr_Transforms.FindAction("Head_Rotation", throwIfNotFound: true);
        m_Vr_Transforms_Hand_Left_Position = m_Vr_Transforms.FindAction("Hand_Left_Position", throwIfNotFound: true);
        m_Vr_Transforms_Hand_Left_Rotation = m_Vr_Transforms.FindAction("Hand_Left_Rotation", throwIfNotFound: true);
        m_Vr_Transforms_Hand_Right_Position = m_Vr_Transforms.FindAction("Hand_Right_Position", throwIfNotFound: true);
        m_Vr_Transforms_Hand_Right_Rotation = m_Vr_Transforms.FindAction("Hand_Right_Rotation", throwIfNotFound: true);
        // Controls
        m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
        m_Controls_Look_NonVr = m_Controls.FindAction("Look_NonVr", throwIfNotFound: true);
        m_Controls_Look_Vr = m_Controls.FindAction("Look_Vr", throwIfNotFound: true);
        m_Controls_Movement_Vr = m_Controls.FindAction("Movement_Vr", throwIfNotFound: true);
        m_Controls_Movement_Forward = m_Controls.FindAction("Movement_Forward", throwIfNotFound: true);
        m_Controls_Movement_Strafe_Right = m_Controls.FindAction("Movement_Strafe_Right", throwIfNotFound: true);
        m_Controls_Movement_Backward = m_Controls.FindAction("Movement_Backward", throwIfNotFound: true);
        m_Controls_Movement_Strafe_Left = m_Controls.FindAction("Movement_Strafe_Left", throwIfNotFound: true);
        m_Controls_PullArrow_Vr = m_Controls.FindAction("PullArrow_Vr", throwIfNotFound: true);
        m_Controls_PullTeleportArrow_Vr = m_Controls.FindAction("PullTeleportArrow_Vr", throwIfNotFound: true);
        m_Controls_PullArrow_NonVr = m_Controls.FindAction("PullArrow_NonVr", throwIfNotFound: true);
        m_Controls_PullTeleportArrow_NonVr = m_Controls.FindAction("PullTeleportArrow_NonVr", throwIfNotFound: true);
        m_Controls_PauseToggle = m_Controls.FindAction("PauseToggle", throwIfNotFound: true);
        m_Controls_MouseLookEnable = m_Controls.FindAction("MouseLookEnable", throwIfNotFound: true);
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

    // Vr_Transforms
    private readonly InputActionMap m_Vr_Transforms;
    private IVr_TransformsActions m_Vr_TransformsActionsCallbackInterface;
    private readonly InputAction m_Vr_Transforms_Head_Position;
    private readonly InputAction m_Vr_Transforms_Head_Rotation;
    private readonly InputAction m_Vr_Transforms_Hand_Left_Position;
    private readonly InputAction m_Vr_Transforms_Hand_Left_Rotation;
    private readonly InputAction m_Vr_Transforms_Hand_Right_Position;
    private readonly InputAction m_Vr_Transforms_Hand_Right_Rotation;
    public struct Vr_TransformsActions
    {
        private @App_Input m_Wrapper;
        public Vr_TransformsActions(@App_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Head_Position => m_Wrapper.m_Vr_Transforms_Head_Position;
        public InputAction @Head_Rotation => m_Wrapper.m_Vr_Transforms_Head_Rotation;
        public InputAction @Hand_Left_Position => m_Wrapper.m_Vr_Transforms_Hand_Left_Position;
        public InputAction @Hand_Left_Rotation => m_Wrapper.m_Vr_Transforms_Hand_Left_Rotation;
        public InputAction @Hand_Right_Position => m_Wrapper.m_Vr_Transforms_Hand_Right_Position;
        public InputAction @Hand_Right_Rotation => m_Wrapper.m_Vr_Transforms_Hand_Right_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_Vr_Transforms; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Vr_TransformsActions set) { return set.Get(); }
        public void SetCallbacks(IVr_TransformsActions instance)
        {
            if (m_Wrapper.m_Vr_TransformsActionsCallbackInterface != null)
            {
                @Head_Position.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Position;
                @Head_Position.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Position;
                @Head_Position.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Position;
                @Head_Rotation.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Rotation;
                @Head_Rotation.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Rotation;
                @Head_Rotation.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHead_Rotation;
                @Hand_Left_Position.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Position;
                @Hand_Left_Position.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Position;
                @Hand_Left_Position.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Position;
                @Hand_Left_Rotation.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Rotation;
                @Hand_Left_Rotation.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Rotation;
                @Hand_Left_Rotation.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Left_Rotation;
                @Hand_Right_Position.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Position;
                @Hand_Right_Position.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Position;
                @Hand_Right_Position.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Position;
                @Hand_Right_Rotation.started -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Rotation;
                @Hand_Right_Rotation.performed -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Rotation;
                @Hand_Right_Rotation.canceled -= m_Wrapper.m_Vr_TransformsActionsCallbackInterface.OnHand_Right_Rotation;
            }
            m_Wrapper.m_Vr_TransformsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Head_Position.started += instance.OnHead_Position;
                @Head_Position.performed += instance.OnHead_Position;
                @Head_Position.canceled += instance.OnHead_Position;
                @Head_Rotation.started += instance.OnHead_Rotation;
                @Head_Rotation.performed += instance.OnHead_Rotation;
                @Head_Rotation.canceled += instance.OnHead_Rotation;
                @Hand_Left_Position.started += instance.OnHand_Left_Position;
                @Hand_Left_Position.performed += instance.OnHand_Left_Position;
                @Hand_Left_Position.canceled += instance.OnHand_Left_Position;
                @Hand_Left_Rotation.started += instance.OnHand_Left_Rotation;
                @Hand_Left_Rotation.performed += instance.OnHand_Left_Rotation;
                @Hand_Left_Rotation.canceled += instance.OnHand_Left_Rotation;
                @Hand_Right_Position.started += instance.OnHand_Right_Position;
                @Hand_Right_Position.performed += instance.OnHand_Right_Position;
                @Hand_Right_Position.canceled += instance.OnHand_Right_Position;
                @Hand_Right_Rotation.started += instance.OnHand_Right_Rotation;
                @Hand_Right_Rotation.performed += instance.OnHand_Right_Rotation;
                @Hand_Right_Rotation.canceled += instance.OnHand_Right_Rotation;
            }
        }
    }
    public Vr_TransformsActions @Vr_Transforms => new Vr_TransformsActions(this);

    // Controls
    private readonly InputActionMap m_Controls;
    private IControlsActions m_ControlsActionsCallbackInterface;
    private readonly InputAction m_Controls_Look_NonVr;
    private readonly InputAction m_Controls_Look_Vr;
    private readonly InputAction m_Controls_Movement_Vr;
    private readonly InputAction m_Controls_Movement_Forward;
    private readonly InputAction m_Controls_Movement_Strafe_Right;
    private readonly InputAction m_Controls_Movement_Backward;
    private readonly InputAction m_Controls_Movement_Strafe_Left;
    private readonly InputAction m_Controls_PullArrow_Vr;
    private readonly InputAction m_Controls_PullTeleportArrow_Vr;
    private readonly InputAction m_Controls_PullArrow_NonVr;
    private readonly InputAction m_Controls_PullTeleportArrow_NonVr;
    private readonly InputAction m_Controls_PauseToggle;
    private readonly InputAction m_Controls_MouseLookEnable;
    public struct ControlsActions
    {
        private @App_Input m_Wrapper;
        public ControlsActions(@App_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Look_NonVr => m_Wrapper.m_Controls_Look_NonVr;
        public InputAction @Look_Vr => m_Wrapper.m_Controls_Look_Vr;
        public InputAction @Movement_Vr => m_Wrapper.m_Controls_Movement_Vr;
        public InputAction @Movement_Forward => m_Wrapper.m_Controls_Movement_Forward;
        public InputAction @Movement_Strafe_Right => m_Wrapper.m_Controls_Movement_Strafe_Right;
        public InputAction @Movement_Backward => m_Wrapper.m_Controls_Movement_Backward;
        public InputAction @Movement_Strafe_Left => m_Wrapper.m_Controls_Movement_Strafe_Left;
        public InputAction @PullArrow_Vr => m_Wrapper.m_Controls_PullArrow_Vr;
        public InputAction @PullTeleportArrow_Vr => m_Wrapper.m_Controls_PullTeleportArrow_Vr;
        public InputAction @PullArrow_NonVr => m_Wrapper.m_Controls_PullArrow_NonVr;
        public InputAction @PullTeleportArrow_NonVr => m_Wrapper.m_Controls_PullTeleportArrow_NonVr;
        public InputAction @PauseToggle => m_Wrapper.m_Controls_PauseToggle;
        public InputAction @MouseLookEnable => m_Wrapper.m_Controls_MouseLookEnable;
        public InputActionMap Get() { return m_Wrapper.m_Controls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
        public void SetCallbacks(IControlsActions instance)
        {
            if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
            {
                @Look_NonVr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_NonVr;
                @Look_NonVr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_NonVr;
                @Look_NonVr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_NonVr;
                @Look_Vr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_Vr;
                @Look_Vr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_Vr;
                @Look_Vr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnLook_Vr;
                @Movement_Vr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Vr;
                @Movement_Vr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Vr;
                @Movement_Vr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Vr;
                @Movement_Forward.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Forward;
                @Movement_Forward.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Forward;
                @Movement_Forward.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Forward;
                @Movement_Strafe_Right.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Backward.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Backward;
                @Movement_Backward.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Backward;
                @Movement_Backward.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Backward;
                @Movement_Strafe_Left.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMovement_Strafe_Left;
                @PullArrow_Vr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_Vr;
                @PullArrow_Vr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_Vr;
                @PullArrow_Vr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_Vr;
                @PullTeleportArrow_Vr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_Vr;
                @PullTeleportArrow_Vr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_Vr;
                @PullTeleportArrow_Vr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_Vr;
                @PullArrow_NonVr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_NonVr;
                @PullArrow_NonVr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_NonVr;
                @PullArrow_NonVr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullArrow_NonVr;
                @PullTeleportArrow_NonVr.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_NonVr;
                @PullTeleportArrow_NonVr.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_NonVr;
                @PullTeleportArrow_NonVr.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPullTeleportArrow_NonVr;
                @PauseToggle.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseToggle;
                @PauseToggle.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseToggle;
                @PauseToggle.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnPauseToggle;
                @MouseLookEnable.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLookEnable;
                @MouseLookEnable.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLookEnable;
                @MouseLookEnable.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnMouseLookEnable;
            }
            m_Wrapper.m_ControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Look_NonVr.started += instance.OnLook_NonVr;
                @Look_NonVr.performed += instance.OnLook_NonVr;
                @Look_NonVr.canceled += instance.OnLook_NonVr;
                @Look_Vr.started += instance.OnLook_Vr;
                @Look_Vr.performed += instance.OnLook_Vr;
                @Look_Vr.canceled += instance.OnLook_Vr;
                @Movement_Vr.started += instance.OnMovement_Vr;
                @Movement_Vr.performed += instance.OnMovement_Vr;
                @Movement_Vr.canceled += instance.OnMovement_Vr;
                @Movement_Forward.started += instance.OnMovement_Forward;
                @Movement_Forward.performed += instance.OnMovement_Forward;
                @Movement_Forward.canceled += instance.OnMovement_Forward;
                @Movement_Strafe_Right.started += instance.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.performed += instance.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.canceled += instance.OnMovement_Strafe_Right;
                @Movement_Backward.started += instance.OnMovement_Backward;
                @Movement_Backward.performed += instance.OnMovement_Backward;
                @Movement_Backward.canceled += instance.OnMovement_Backward;
                @Movement_Strafe_Left.started += instance.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.performed += instance.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.canceled += instance.OnMovement_Strafe_Left;
                @PullArrow_Vr.started += instance.OnPullArrow_Vr;
                @PullArrow_Vr.performed += instance.OnPullArrow_Vr;
                @PullArrow_Vr.canceled += instance.OnPullArrow_Vr;
                @PullTeleportArrow_Vr.started += instance.OnPullTeleportArrow_Vr;
                @PullTeleportArrow_Vr.performed += instance.OnPullTeleportArrow_Vr;
                @PullTeleportArrow_Vr.canceled += instance.OnPullTeleportArrow_Vr;
                @PullArrow_NonVr.started += instance.OnPullArrow_NonVr;
                @PullArrow_NonVr.performed += instance.OnPullArrow_NonVr;
                @PullArrow_NonVr.canceled += instance.OnPullArrow_NonVr;
                @PullTeleportArrow_NonVr.started += instance.OnPullTeleportArrow_NonVr;
                @PullTeleportArrow_NonVr.performed += instance.OnPullTeleportArrow_NonVr;
                @PullTeleportArrow_NonVr.canceled += instance.OnPullTeleportArrow_NonVr;
                @PauseToggle.started += instance.OnPauseToggle;
                @PauseToggle.performed += instance.OnPauseToggle;
                @PauseToggle.canceled += instance.OnPauseToggle;
                @MouseLookEnable.started += instance.OnMouseLookEnable;
                @MouseLookEnable.performed += instance.OnMouseLookEnable;
                @MouseLookEnable.canceled += instance.OnMouseLookEnable;
            }
        }
    }
    public ControlsActions @Controls => new ControlsActions(this);
    public interface IVr_TransformsActions
    {
        void OnHead_Position(InputAction.CallbackContext context);
        void OnHead_Rotation(InputAction.CallbackContext context);
        void OnHand_Left_Position(InputAction.CallbackContext context);
        void OnHand_Left_Rotation(InputAction.CallbackContext context);
        void OnHand_Right_Position(InputAction.CallbackContext context);
        void OnHand_Right_Rotation(InputAction.CallbackContext context);
    }
    public interface IControlsActions
    {
        void OnLook_NonVr(InputAction.CallbackContext context);
        void OnLook_Vr(InputAction.CallbackContext context);
        void OnMovement_Vr(InputAction.CallbackContext context);
        void OnMovement_Forward(InputAction.CallbackContext context);
        void OnMovement_Strafe_Right(InputAction.CallbackContext context);
        void OnMovement_Backward(InputAction.CallbackContext context);
        void OnMovement_Strafe_Left(InputAction.CallbackContext context);
        void OnPullArrow_Vr(InputAction.CallbackContext context);
        void OnPullTeleportArrow_Vr(InputAction.CallbackContext context);
        void OnPullArrow_NonVr(InputAction.CallbackContext context);
        void OnPullTeleportArrow_NonVr(InputAction.CallbackContext context);
        void OnPauseToggle(InputAction.CallbackContext context);
        void OnMouseLookEnable(InputAction.CallbackContext context);
    }
}
