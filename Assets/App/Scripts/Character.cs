using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  [Header("Stats")]
  public int StartingHitpoints = 7;
  public int MaxHitpoints = 10;
  public float Speed = 2.0f;
  public float DashSpeed = 6.0f;
  [Header("Body parts")]
  public HitReactor[] HitReactors;
  public Transform Head;
  public Transform Head_UpDown;
  public Transform Hand_Left;
  public Transform Hand_Right;
  public Transform Body;
  [Header("System")]
  public CharacterRpcs Rpcs;
  [Header("Held")]
  public Bow MyBow;

  [NonSerialized] public Vector2 MovementInput;
  [NonSerialized] public bool IsDashing;

  public int Hitpoints
  {
    get { return _hitpoints; }
    set
    {
      if (value == _hitpoints) { return; }
      if (_isLocalPc)
      {
        var newHitpoints = Mathf.Clamp(value, 0, MaxHitpoints);
        if (newHitpoints < Hitpoints)
        {
          App_Functions.Instance.FlashDamageOverlay();
        }
        _hitpoints = newHitpoints;
      }
      else
      {
         _hitpoints = Mathf.Clamp(value, 0, MaxHitpoints);
      }
      StartingHitpoints = value;
      if (MyBow) { MyBow.HitpointValues = new Vector2Int(Hitpoints, MaxHitpoints); }
    }
  }
  private int _hitpoints = 0;

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
  private bool _isLocalPc;

  private void Start()
  {
    var netIdentity = GetComponent<NetworkIdentity>();

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

    Hitpoints = StartingHitpoints;

    // Allow for up to ~10000 nonnetworked (preassigned) HitReactors and ~429k networked objects
    var reactorIdOffset = (netIdentity.netId + 1) * 10000;
    for (uint i = 0; i < HitReactors.Length; i++)
    {
      if (HitReactors[i].ReactorId == 0)
      {
        HitReactors[i].ReactorId = i + reactorIdOffset;
      }
    }

    _isLocalPc = (NetworkClient.localPlayer == netIdentity);
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
