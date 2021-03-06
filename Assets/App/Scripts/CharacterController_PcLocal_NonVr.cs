using System.Collections;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class CharacterController_PcLocal_NonVr : CharacterController_PcLocal
{
  public Vector3 LeftHandPullPosition;
  public Vector3 RightHandPullPosition;
  public float MouseLookSensitivity = 0.75f;
  public float MouseAimSensitivity = 0.0005f;
  public Vector2 MouseAimMin = new Vector2(-0.525f, 0.75f);
  public Vector2 MouseAimMax = new Vector2(0.525f, 1.65f);

  private Vector2 _movementInput;
  private bool _paused;
  private bool _isLooking;
  private bool _isUnlooking;
  private Vector3 _leftHandDefaultPosition;
  private Vector3 _rightHandDefaultPosition;
  private bool _priorIsWeaponActivated;

  protected override void Start()
  {
    base.Start();
    if (!enabled) { return; }

    if (!App_Details.Instance.IN_VR)
    {
      _input.Controls.Movement_Forward.started += OnMovementForward_Down;
      _input.Controls.Movement_Forward.canceled += OnMovementForward_Up;
      _input.Controls.Movement_Strafe_Right.started += OnMovementRight_Down;
      _input.Controls.Movement_Strafe_Right.canceled += OnMovementRight_Up;
      _input.Controls.Movement_Backward.started += OnMovementBackward_Down;
      _input.Controls.Movement_Backward.canceled += OnMovementBackward_Up;
      _input.Controls.Movement_Strafe_Left.started += OnMovementLeft_Down;
      _input.Controls.Movement_Strafe_Left.canceled += OnMovementLeft_Up;
      _input.Controls.PullArrow_NonVr.started += OnPullArrow_Down;
      _input.Controls.PullArrow_NonVr.canceled += OnPullArrow_Up;
      _input.Controls.PullTeleportArrow_NonVr.started += OnPullTeleportArrow_Down;
      _input.Controls.PullTeleportArrow_NonVr.canceled += OnPullTeleportArrow_Up;
      _input.Controls.MouseLookEnable.started += OnMouseLookEnabled_Down;
      _input.Controls.MouseLookEnable.canceled += OnMouseLookEnabled_Up;
      _leftHandDefaultPosition = _character.Hand_Left.localPosition;
      _rightHandDefaultPosition = _character.Hand_Right.localPosition;
      _input.Controls.PauseToggle.performed += onPauseToggled;
      _paused = true;
      onPauseToggled(new CallbackContext());
    }
    else
    {
      enabled = false;
    }
  }

  private void onPauseToggled(CallbackContext obj)
  {
    _paused = !_paused;
    if (_paused)
    {
      Cursor.lockState = CursorLockMode.None;
    }
    else
    {
      Cursor.lockState = CursorLockMode.Locked;
    }
  }

  private void Update()
  {
    if (_paused) { return; }

    _character.MovementInput = _movementInput;
    var lookDelta = _input.Controls.Look_NonVr.ReadValue<Vector2>();
    var isArrowPulled = _character.Class.GetFlag(CharacterClass_Archer.Flag_IsPulling);

    // Look up/down
    if (!isArrowPulled)
    {
      var t = _character.Head_UpDown.localEulerAngles;
      t.x -= lookDelta.y * MouseLookSensitivity;
      if (t.x < 180.0 && t.x > 60.0f) { t.x = 60.0f; }
      else if (t.x > 180.0 && t.x < 285.0f) { t.x = 285.0f; }
      _character.Head_UpDown.localEulerAngles = t;
    }

    // Turn left/right
    if (!isArrowPulled && !_isLooking)
    {
      var t = _character.transform.localEulerAngles;
      t.y += lookDelta.x * MouseLookSensitivity;
      _character.transform.localEulerAngles = t;
    }

    // Look left/right
    if (!isArrowPulled && _isLooking)
    {
      var t = _character.Head.localEulerAngles;
      t.y += lookDelta.x * MouseLookSensitivity;
      _character.Head.localEulerAngles = t;
    }

    // Maneuver the bow
    if (isArrowPulled)
    {
      // Adjust right hand position via mouse
      var newRightHandPosition =
        _character.Hand_Right.localPosition +
        new Vector3(lookDelta.x, lookDelta.y, 0.0f) * MouseAimSensitivity;
      // X bounds
      if (newRightHandPosition.x < MouseAimMin.x)
      {
        newRightHandPosition.x = MouseAimMin.x;
      }
      else if (newRightHandPosition.x > MouseAimMax.x)
      {
        newRightHandPosition.x = MouseAimMax.x;
      }
      // Y bounds
      if (newRightHandPosition.y < MouseAimMin.y)
      {
        newRightHandPosition.y = MouseAimMin.y;
      }
      else if (newRightHandPosition.y > MouseAimMax.y)
      {
        newRightHandPosition.y = MouseAimMax.y;
      }
      // Finish
      _character.Hand_Right.localPosition = newRightHandPosition;
    }
  }

  private IEnumerator UnlookCoroutine()
  {
    if (_isUnlooking) { yield break; }
    _isUnlooking = true;
    while (!_isLooking)
    {
      // Unturn
      var t = _character.Head.localEulerAngles;
      var lookingRight = (t.y > 0.0f && t.y < 180.0f);
      t.y += lookingRight ? -1.0f : 1.0f;
      _character.Head.localEulerAngles = t;
      // Handle finished unturning
      if ((t.y > 0.0f && t.y < 180.0f) != lookingRight)
      {
        t.y = 0;
        _character.Head.localEulerAngles = t;
        break;
      }
      // Wait for next frame
      yield return null;
    }
    _isUnlooking = false;
  }

  private void OnMovementForward_Down(CallbackContext obj) { _movementInput.y = 1.0f; }
  private void OnMovementForward_Up(CallbackContext obj) { _movementInput.y = 0.0f; }
  private void OnMovementRight_Down(CallbackContext obj) { _movementInput.x = 1.0f; }
  private void OnMovementRight_Up(CallbackContext obj) { _movementInput.x = 0.0f; }
  private void OnMovementBackward_Down(CallbackContext obj) { _movementInput.y = -1.0f; }
  private void OnMovementBackward_Up(CallbackContext obj) { _movementInput.y = 0.0f; }
  private void OnMovementLeft_Down(CallbackContext obj) { _movementInput.x = -1.0f; }
  private void OnMovementLeft_Up(CallbackContext obj) { _movementInput.x = 0.0f; }
  private void OnMouseLookEnabled_Down(CallbackContext obj) { _isLooking = true; }
  private void OnMouseLookEnabled_Up(CallbackContext obj)
  {
    _isLooking = false;
    StartCoroutine(UnlookCoroutine());
  }
  private void OnPullArrow_Down(CallbackContext obj)
  {
    if (_paused) { return; }
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsTeleporting, false);
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsPulling, true);
    _character.Hand_Left.localPosition = LeftHandPullPosition;
    _character.Hand_Right.localPosition = RightHandPullPosition;
  }
  private void OnPullArrow_Up(CallbackContext obj)
  {
    if (_paused) { return; }
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsPulling, false);
    _character.Hand_Left.localPosition = _leftHandDefaultPosition;
    _character.Hand_Right.localPosition = _rightHandDefaultPosition;
  }
  private void OnPullTeleportArrow_Down(CallbackContext obj)
  {
    if (_paused) { return; }
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsTeleporting, true);
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsPulling, true);
    _character.Hand_Left.localPosition = LeftHandPullPosition;
    _character.Hand_Right.localPosition = RightHandPullPosition;
  }
  private void OnPullTeleportArrow_Up(CallbackContext obj)
  {
    if (_paused) { return; }
    _character.Class.SetFlag(CharacterClass_Archer.Flag_IsPulling, false);
    _character.Hand_Left.localPosition = _leftHandDefaultPosition;
    _character.Hand_Right.localPosition = _rightHandDefaultPosition;
  }
}
