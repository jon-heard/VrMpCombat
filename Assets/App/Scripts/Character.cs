using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  [Header("Stats")]
  public float Speed = 2.0f;
  public float DashSpeed = 6.0f;
  [Header("Body parts")]
  public Transform Head;
  public Transform Head_UpDown;
  public Transform Hand_Left;
  public Transform Hand_Right;
  public Transform Body;
  [Header("Held")]
  public Bow MyBow;

  [NonSerialized] public Vector2 MovementInput;
  [NonSerialized] public bool IsDashing;

  public List<Collider> Colliders { get; private set; }

  public bool IsPullingBow
  {
    get { return _isPullingBow; }
    set
    {
      if (value == _isPullingBow) { return; }
      _isPullingBow = value;
      MyBow.IsPulling = _isPullingBow;
    }
  }
  private bool _isPullingBow;

  public void Turn(bool left)
  {
    var t = transform.localEulerAngles;
    t.y += _ControllerTurnAmount * (left ? 1.0f : -1.0f);
    transform.localEulerAngles = t;
  }

  private float _ControllerTurnAmount;

  private void Start()
  {
    _ControllerTurnAmount = App_Details.Instance.CONTROLLER_TURN_AMOUNT;

    Colliders = new List<Collider>();
    foreach (Transform t in Head)
    {
      var c = t.GetComponent<Collider>();
      if (c) { Colliders.Add(c); }
    }
    foreach (Transform t in Hand_Left)
    {
      var c = t.GetComponent<Collider>();
      if (c) { Colliders.Add(c); }
    }
    foreach (Transform t in Hand_Right)
    {
      var c = t.GetComponent<Collider>();
      if (c) { Colliders.Add(c); }
    }
    foreach (Transform t in Body)
    {
      var c = t.GetComponent<Collider>();
      if (c) { Colliders.Add(c); }
    }
  }

  private void Update()
  {
    if (MovementInput.sqrMagnitude > 1.0f)
    {
      MovementInput.Normalize();
    }

    if (MovementInput.y != 0)
    {
      var t = transform.localPosition;
      t += transform.forward * MovementInput.y * (IsDashing ? DashSpeed : Speed) * Time.deltaTime;
      transform.localPosition = t;
    }
    if (MovementInput.x != 0)
    {
      var t = transform.localPosition;
      t += transform.right * MovementInput.x * (IsDashing ? DashSpeed : Speed) * Time.deltaTime;
      transform.localPosition = t;
    }
  }
}
