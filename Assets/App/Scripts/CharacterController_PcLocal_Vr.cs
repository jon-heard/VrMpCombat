using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterController_PcLocal_Vr : CharacterController_PcLocal
{
#if UNITY_EDITOR
  [Header("VR simulation")]
  public bool IsLeftTriggerDown = false;
  private bool _prevIsLeftTriggerDown;
  [Range(-1.0f, 1.0f)]
  public float LeftThumbX = 0.0f;
  [Range(-1.0f, 1.0f)]
  public float LeftThumbY = 0.0f;
  [Range(-1.0f, 1.0f)]
  public float RightThumbX = 0.0f;
#endif

  private Vector3 _baseHeadPosition;
  private Vector3 _vrPositionOffset;
  private int _rightThumbXState = 0;

  protected override void Start()
  {
    base.Start();

    if (App_Details.Instance.IN_VR)
    {
      Camera.onPreRender += OnPreRender;
      _input.Controls.PullBow.started += OnPullBow_Down;
      _input.Controls.PullBow.canceled += OnPullBow_Up;
      StartCoroutine(UpdateCoroutine());
    }
    else
    {
      enabled = false;
      StartCoroutine(UpdateCoroutine_SimulatedVr());
    }

    _baseHeadPosition = _character.Head.localPosition;
    _vrPositionOffset = _input.Vr_Transforms.Head_Position.ReadValue<Vector3>();
  }

  private IEnumerator UpdateCoroutine()
  {
    while (true)
    {
      _character.MovementInput = _input.Controls.Movement_Vr.ReadValue<Vector2>();
      var rightThumbX = _input.Controls.Look_Vr.ReadValue<Vector2>().x;
      var newRightThumbXState = rightThumbX > 0.5f ? 1 : rightThumbX < -0.5f ? -1 : 0;
      if (newRightThumbXState != _rightThumbXState)
      {
        _rightThumbXState = newRightThumbXState;
        if (_rightThumbXState != 0)
        {
          _character.Turn(_rightThumbXState > 0.0f);
        }
      }
      yield return null;
    }
  }

  private IEnumerator UpdateCoroutine_SimulatedVr()
  {
    while (true)
    {
      _character.MovementInput = new Vector2(LeftThumbX, LeftThumbY);
      var rightThumbX = RightThumbX;
      var newRightThumbXState = rightThumbX > 0.5f ? 1 : rightThumbX < -0.5f ? -1 : 0;
      if (newRightThumbXState != _rightThumbXState)
      {
        _rightThumbXState = newRightThumbXState;
        if (_rightThumbXState != 0)
        {
          _character.Turn(_rightThumbXState > 0.0f);
        }
      }
      yield return null;
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
#endif
    var posOffset = -_vrPositionOffset + (Application.isMobilePlatform ? _baseHeadPosition : Vector3.zero);
    _character.Head.localPosition = _input.Vr_Transforms.Head_Position.ReadValue<Vector3>() + posOffset;
    _character.Head.localRotation = _input.Vr_Transforms.Head_Rotation.ReadValue<Quaternion>();
    _character.Hand_Left.localPosition = _input.Vr_Transforms.Hand_Left_Position.ReadValue<Vector3>() + posOffset;
    _character.Hand_Left.localRotation = _input.Vr_Transforms.Hand_Left_Rotation.ReadValue<Quaternion>();
    _character.Hand_Right.localPosition = _input.Vr_Transforms.Hand_Right_Position.ReadValue<Vector3>() + posOffset;
    _character.Hand_Right.localRotation = _input.Vr_Transforms.Hand_Right_Rotation.ReadValue<Quaternion>();
  }

  private void OnPullBow_Down(CallbackContext obj)
  {
    if ((_character.Hand_Left.position - _character.Hand_Right.position).sqrMagnitude <=
          _maxDistanceTriggerBowPullSquared)
    {
      _character.IsPullingBow = true;
    }
  }
  private void OnPullBow_Up(CallbackContext obj)
  {
    _character.IsPullingBow = false;
  }
}
