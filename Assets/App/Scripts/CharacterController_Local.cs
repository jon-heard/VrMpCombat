using UnityEngine;

public class CharacterController_Local : MonoBehaviour
{
#if UNITY_EDITOR
  [Header("VR simulation")]
  [Range(-1.0f, 1.0f)]
  public float LeftThumbX = 0.0f;
  [Range(-1.0f, 1.0f)]
  public float LeftThumbY = 0.0f;
  [Range(-1.0f, 1.0f)]
  public float RightThumbX = 0.0f;
#endif

  private bool _inVr;
  private Character _character;
  private App_Input _input;
  private Vector3 _normalHeadPositionOffset;
  private Vector3 _vrPositionOffset;
  private int _rightThumbXState = 0;

  private void Start()
  {
    _character = GetComponent<Character>();
    _input = new App_Input();
    _input.Enable();
    _input.VrInput.PullBow.started += OnLeftTriggerDown;
    _input.VrInput.PullBow.canceled += OnLeftTriggerUp;
    Camera.onPreRender += OnPreRender;
    _normalHeadPositionOffset = _character.Head.localPosition;
    _vrPositionOffset = _input.Vr_Transforms.Head_Position.ReadValue<Vector3>();
    _inVr = App_Details.Instance.IN_VR;
  }

  private void Update()
  {
    float rightThumbX;
#if UNITY_EDITOR
    if (!_inVr)
    {
      _character.MovementInput = new Vector2(LeftThumbX, LeftThumbY);
      rightThumbX = RightThumbX;
    }
    else
#endif
    {
      _character.MovementInput = _input.VrInput.Movement.ReadValue<Vector2>();
      rightThumbX = _input.VrInput.RightThumb.ReadValue<Vector2>().x;
    }

    var newRightThumbXState = rightThumbX > 0.5f ? 1 : rightThumbX < -0.5f ? -1 : 0;
    if (newRightThumbXState != _rightThumbXState)
    {
      _rightThumbXState = newRightThumbXState;
      if (_rightThumbXState != 0)
      {
        _character.Turn(_rightThumbXState > 0.0f);
      }
    }
  }

  private void OnDestroy()
  {
    Camera.onPreRender -= OnPreRender;
  }

  private void OnPreRender(Camera c)
  {
#if UNITY_EDITOR
    if (!Application.isPlaying) { return; }
    if (_inVr)
#endif
    {
      var posOffset = -_vrPositionOffset + (Application.isMobilePlatform ? _normalHeadPositionOffset : Vector3.zero);
      _character.Head.localPosition = _input.Vr_Transforms.Head_Position.ReadValue<Vector3>() + posOffset;
      _character.Head.localRotation = _input.Vr_Transforms.Head_Rotation.ReadValue<Quaternion>();
      _character.Hand_Left.localPosition = _input.Vr_Transforms.Hand_Left_Position.ReadValue<Vector3>() + posOffset;
      _character.Hand_Left.localRotation = _input.Vr_Transforms.Hand_Left_Rotation.ReadValue<Quaternion>();
      _character.Hand_Right.localPosition = _input.Vr_Transforms.Hand_Right_Position.ReadValue<Vector3>() + posOffset;
      _character.Hand_Right.localRotation = _input.Vr_Transforms.Hand_Right_Rotation.ReadValue<Quaternion>();
    }
  }

  private void OnLeftTriggerDown(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    _character.IsPullingBow = true;
  }

  private void OnLeftTriggerUp(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    _character.IsPullingBow = false;
  }
}
