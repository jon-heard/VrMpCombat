using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
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
    if (!enabled) { return; }

    if (App_Details.Instance.IN_VR)
    {
      InputSystem.onAfterUpdate += RefreshTracking;
      _input.Controls.PullBow.started += OnPullBow_Down;
      _input.Controls.PullBow.canceled += OnPullBow_Up;
      _input.Controls.Dash.started += OnDash_Down;
      _input.Controls.Dash.canceled += OnDash_Up;
      StartCoroutine(UpdateCoroutine());
    }
    else
    {
      enabled = false;
#if UNITY_EDITOR
      StartCoroutine(UpdateCoroutine_SimulatedVr());
#endif
    }

    _baseHeadPosition = _character.Head.localPosition;
    _vrPositionOffset = _input.Vr_Transforms.Head_Position.ReadValue<Vector3>();
  }

  private void OnDestroy()
  {
    InputSystem.onAfterUpdate -= RefreshTracking;
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

#if UNITY_EDITOR
  private IEnumerator UpdateCoroutine_SimulatedVr()
  {
    while (true)
    {
      yield return new WaitUntil(() => { return enabled; });
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
#endif

  private void RefreshTracking()
  {
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
  private void OnPullBow_Up(CallbackContext obj) { _character.IsPullingBow = false; }
  private void OnDash_Down(CallbackContext obj) { _character.IsDashing = true; }
  private void OnDash_Up(CallbackContext obj) { _character.IsDashing = false; }
}
