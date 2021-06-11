using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  [Header("Stats")]
  public float Speed = 1.0f;
  [Header("Body parts")]
  public Transform Head;
  public Transform Hand_Left;
  public Transform Hand_Right;
  public Transform Body;
  [Header("Held")]
  public Bow MyBow;

  [NonSerialized] public Vector2 MovementInput;

  public bool IsPullingBow
  {
    get { return _isPullingBow; }
    set
    {
      if (value == _isPullingBow) { return; }
      if (value &&
          (Hand_Left.position - Hand_Right.position).sqrMagnitude >
          _maxDistanceTriggerBowPullSquared)
      {
        return;
      }
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

  private float _maxDistanceTriggerBowPullSquared;
  private float _ControllerTurnAmount;

  private void Start()
  {
    _maxDistanceTriggerBowPullSquared =
      Mathf.Pow(App_Details.Instance.MAX_DISTANCE_TRIGGER_BOWPULL, 2);
    _ControllerTurnAmount = App_Details.Instance.CONTROLLER_TURN_AMOUNT;

    // Setup Ignore list for arrows to not contact characters body
    if (MyBow)
    {
      var toIgnore = new List<Collider>();
      foreach (Transform t in Head)
      {
        var c = t.GetComponent<Collider>();
        if (c) { toIgnore.Add(c); }
      }
      foreach (Transform t in Hand_Left)
      {
        var c = t.GetComponent<Collider>();
        if (c) { toIgnore.Add(c); }
      }
      foreach (Transform t in Hand_Right)
      {
        var c = t.GetComponent<Collider>();
        if (c) { toIgnore.Add(c); }
      }
      foreach (Transform t in Body)
      {
        var c = t.GetComponent<Collider>();
        if (c) { toIgnore.Add(c); }
      }
      MyBow.ToIgnore = toIgnore;
    }
  }

  private void Update()
  {
    if (MovementInput.y != 0)
    {
      var t = transform.localPosition;
      t += transform.forward * MovementInput.y * Speed * Time.deltaTime;
      transform.localPosition = t;
    }
    if (MovementInput.x != 0)
    {
      var t = transform.localPosition;
      t += transform.right * MovementInput.x * Speed * Time.deltaTime;
      transform.localPosition = t;
    }
  }
}
