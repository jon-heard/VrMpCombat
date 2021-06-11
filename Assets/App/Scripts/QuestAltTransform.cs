using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAltTransform : MonoBehaviour
{
  public Vector3 Position;
  public Vector3 Rotation;
  public bool MainControl = false;
  public uint Index = 0;

  private App_Input _input;
  private Vector3 _originalPosition;

  private static uint _currentIndex = 0;

  private void Awake()
  {
    _originalPosition = transform.localPosition;
    if (Application.isMobilePlatform)
    {
      transform.localPosition += Position;
      transform.localEulerAngles += Rotation;
    }

    _input = new App_Input();
    _input.VrInput.RotateFist_x_down.started += RotateFist_x_down_started;
    _input.VrInput.RotateFist_x_up.started += RotateFist_x_up_started;
    _input.VrInput.RotateFist_y_down.started += RotateFist_y_down_started;
    _input.VrInput.RotateFist_y_up.started += RotateFist_y_up_started;
    _input.VrInput.RotateFist_z_down.started += RotateFist_z_down_started;
    _input.VrInput.RotateFist_z_up.started += RotateFist_z_up_started;
    if (MainControl)
    {
      _input.VrInput.ChangeRotationFocus.started += ChangeRotationFocus_started;
    }
    _input.Enable();
  }

  private void ChangeRotationFocus_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    _currentIndex++;
    if (_currentIndex > 2) { _currentIndex = 0; }
  }

  private void AdjustRotation(Vector3 adjustment)
  {
    if (_currentIndex != Index) { return; }
    transform.localPosition += adjustment * 0.01f;
    var adjust = (transform.localPosition - _originalPosition);
    Debug.Log("JDEV: rotation adjustment for #" + Index + " set to: " + adjust.x + "," + adjust.y + "," + adjust.z);
  }


  private void RotateFist_z_up_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(0.0f, 0.0f, 1.0f));
  }
  private void RotateFist_z_down_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(0.0f, 0.0f, -1.0f));
  }
  private void RotateFist_y_up_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(0.0f, 1.0f, 0.0f));
  }
  private void RotateFist_y_down_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(0.0f, -1.0f, 0.0f));
  }
  private void RotateFist_x_up_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(1.0f, 0.0f, 0.0f));
  }
  private void RotateFist_x_down_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    AdjustRotation(new Vector3(-1.0f, 0.0f, 0.0f));
  }
}
