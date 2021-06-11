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
            ""name"": ""VrInput"",
            ""id"": ""937cba72-ae89-4aca-8a20-48ef186c134c"",
            ""actions"": [
                {
                    ""name"": ""PullBow"",
                    ""type"": ""Button"",
                    ""id"": ""511d0d41-ea40-4ab0-9c30-39e30740a03c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""188da42c-f424-462e-b841-3d9ea4c92136"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""7b23d85e-c16b-4067-b357-57787f927d22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightThumb"",
                    ""type"": ""Value"",
                    ""id"": ""a10942c5-3fc0-4e7d-977e-8c92acb8f133"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""18d04955-30ba-4aea-ba44-5a8d21e5b5a6"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PullBow"",
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
                    ""action"": ""PullBow"",
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
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f98a77a7-3c2c-4e67-b021-22eff862f9a6"",
                    ""path"": ""<XRController>{LeftHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c84d6e0-9a8d-47da-9afd-01bae51b9c1e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
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
                    ""action"": ""RightThumb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Input"",
            ""id"": ""0d5a9afe-73df-4ca6-8f2b-7bfb8c2e0cf2"",
            ""actions"": [
                {
                    ""name"": ""Movement_Forward"",
                    ""type"": ""Button"",
                    ""id"": ""e84b7550-dee2-452d-a622-dc021594c0b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Strafe_Right"",
                    ""type"": ""Button"",
                    ""id"": ""12855027-229e-4f1e-887b-f34a99eb04b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Backward"",
                    ""type"": ""Button"",
                    ""id"": ""3f7a36e9-e6db-423e-b3f0-dac05f93d5ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement_Strafe_Left"",
                    ""type"": ""Button"",
                    ""id"": ""f6f9be93-4f63-4a7f-af9d-b7df09e49d6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""35943677-1604-4c84-9e65-995fb889cbe4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f86dd7cb-bac5-46b1-be1f-6b25df5fc5b7"",
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
                    ""id"": ""0bf3d939-86de-4750-a073-97dc4c673402"",
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
                    ""id"": ""43354654-1417-40bc-8c86-18db9e20279a"",
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
                    ""id"": ""728ea9d5-397a-4bfc-8462-aa52c34840b2"",
                    ""path"": ""<SwitchProControllerHID>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement_Strafe_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8a63e02-5092-4877-a865-c3193321a6ed"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
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
        // VrInput
        m_VrInput = asset.FindActionMap("VrInput", throwIfNotFound: true);
        m_VrInput_PullBow = m_VrInput.FindAction("PullBow", throwIfNotFound: true);
        m_VrInput_Movement = m_VrInput.FindAction("Movement", throwIfNotFound: true);
        m_VrInput_Dash = m_VrInput.FindAction("Dash", throwIfNotFound: true);
        m_VrInput_RightThumb = m_VrInput.FindAction("RightThumb", throwIfNotFound: true);
        // Input
        m_Input = asset.FindActionMap("Input", throwIfNotFound: true);
        m_Input_Movement_Forward = m_Input.FindAction("Movement_Forward", throwIfNotFound: true);
        m_Input_Movement_Strafe_Right = m_Input.FindAction("Movement_Strafe_Right", throwIfNotFound: true);
        m_Input_Movement_Backward = m_Input.FindAction("Movement_Backward", throwIfNotFound: true);
        m_Input_Movement_Strafe_Left = m_Input.FindAction("Movement_Strafe_Left", throwIfNotFound: true);
        m_Input_Look = m_Input.FindAction("Look", throwIfNotFound: true);
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

    // VrInput
    private readonly InputActionMap m_VrInput;
    private IVrInputActions m_VrInputActionsCallbackInterface;
    private readonly InputAction m_VrInput_PullBow;
    private readonly InputAction m_VrInput_Movement;
    private readonly InputAction m_VrInput_Dash;
    private readonly InputAction m_VrInput_RightThumb;
    public struct VrInputActions
    {
        private @App_Input m_Wrapper;
        public VrInputActions(@App_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @PullBow => m_Wrapper.m_VrInput_PullBow;
        public InputAction @Movement => m_Wrapper.m_VrInput_Movement;
        public InputAction @Dash => m_Wrapper.m_VrInput_Dash;
        public InputAction @RightThumb => m_Wrapper.m_VrInput_RightThumb;
        public InputActionMap Get() { return m_Wrapper.m_VrInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VrInputActions set) { return set.Get(); }
        public void SetCallbacks(IVrInputActions instance)
        {
            if (m_Wrapper.m_VrInputActionsCallbackInterface != null)
            {
                @PullBow.started -= m_Wrapper.m_VrInputActionsCallbackInterface.OnPullBow;
                @PullBow.performed -= m_Wrapper.m_VrInputActionsCallbackInterface.OnPullBow;
                @PullBow.canceled -= m_Wrapper.m_VrInputActionsCallbackInterface.OnPullBow;
                @Movement.started -= m_Wrapper.m_VrInputActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_VrInputActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_VrInputActionsCallbackInterface.OnMovement;
                @Dash.started -= m_Wrapper.m_VrInputActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_VrInputActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_VrInputActionsCallbackInterface.OnDash;
                @RightThumb.started -= m_Wrapper.m_VrInputActionsCallbackInterface.OnRightThumb;
                @RightThumb.performed -= m_Wrapper.m_VrInputActionsCallbackInterface.OnRightThumb;
                @RightThumb.canceled -= m_Wrapper.m_VrInputActionsCallbackInterface.OnRightThumb;
            }
            m_Wrapper.m_VrInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PullBow.started += instance.OnPullBow;
                @PullBow.performed += instance.OnPullBow;
                @PullBow.canceled += instance.OnPullBow;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @RightThumb.started += instance.OnRightThumb;
                @RightThumb.performed += instance.OnRightThumb;
                @RightThumb.canceled += instance.OnRightThumb;
            }
        }
    }
    public VrInputActions @VrInput => new VrInputActions(this);

    // Input
    private readonly InputActionMap m_Input;
    private IInputActions m_InputActionsCallbackInterface;
    private readonly InputAction m_Input_Movement_Forward;
    private readonly InputAction m_Input_Movement_Strafe_Right;
    private readonly InputAction m_Input_Movement_Backward;
    private readonly InputAction m_Input_Movement_Strafe_Left;
    private readonly InputAction m_Input_Look;
    public struct InputActions
    {
        private @App_Input m_Wrapper;
        public InputActions(@App_Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement_Forward => m_Wrapper.m_Input_Movement_Forward;
        public InputAction @Movement_Strafe_Right => m_Wrapper.m_Input_Movement_Strafe_Right;
        public InputAction @Movement_Backward => m_Wrapper.m_Input_Movement_Backward;
        public InputAction @Movement_Strafe_Left => m_Wrapper.m_Input_Movement_Strafe_Left;
        public InputAction @Look => m_Wrapper.m_Input_Look;
        public InputActionMap Get() { return m_Wrapper.m_Input; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActions set) { return set.Get(); }
        public void SetCallbacks(IInputActions instance)
        {
            if (m_Wrapper.m_InputActionsCallbackInterface != null)
            {
                @Movement_Forward.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Forward;
                @Movement_Forward.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Forward;
                @Movement_Forward.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Forward;
                @Movement_Strafe_Right.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Strafe_Right.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Right;
                @Movement_Backward.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Backward;
                @Movement_Backward.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Backward;
                @Movement_Backward.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Backward;
                @Movement_Strafe_Left.started -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Left;
                @Movement_Strafe_Left.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnMovement_Strafe_Left;
                @Look.started -= m_Wrapper.m_InputActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_InputActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_InputActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_InputActionsCallbackInterface = instance;
            if (instance != null)
            {
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
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public InputActions @Input => new InputActions(this);
    public interface IVr_TransformsActions
    {
        void OnHead_Position(InputAction.CallbackContext context);
        void OnHead_Rotation(InputAction.CallbackContext context);
        void OnHand_Left_Position(InputAction.CallbackContext context);
        void OnHand_Left_Rotation(InputAction.CallbackContext context);
        void OnHand_Right_Position(InputAction.CallbackContext context);
        void OnHand_Right_Rotation(InputAction.CallbackContext context);
    }
    public interface IVrInputActions
    {
        void OnPullBow(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnRightThumb(InputAction.CallbackContext context);
    }
    public interface IInputActions
    {
        void OnMovement_Forward(InputAction.CallbackContext context);
        void OnMovement_Strafe_Right(InputAction.CallbackContext context);
        void OnMovement_Backward(InputAction.CallbackContext context);
        void OnMovement_Strafe_Left(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
