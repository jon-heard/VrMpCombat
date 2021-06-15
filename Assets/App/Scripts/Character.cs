using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : NetworkBehaviour
{
  [Header("Stats")]
  [SerializeField] private int _startingHitpoints = 7;
  [SerializeField] private int _maxHitpoints = 10;
  [SerializeField] private float _speed = 2.0f;
  [SerializeField] private float _dashSpeed = 6.0f;
  [Header("Body parts")]
  public HitReactor[] HitReactors;
  public Transform Head;
  public Transform Head_UpDown;
  public Transform Hand_Left;
  public Transform Hand_Right;
  public Transform Body;
  [Header("System")]
  [SerializeField] private Arrow _arrowPrefab;
  [Header("Held")]
  [SerializeField] private Bow _myBow;

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
        var newHitpoints = Mathf.Clamp(value, 0, _maxHitpoints);
        if (newHitpoints < Hitpoints)
        {
          App_Functions.Instance.FlashDamageOverlay();
        }
        _hitpoints = newHitpoints;
      }
      else
      {
         _hitpoints = Mathf.Clamp(value, 0, _maxHitpoints);
      }
      _startingHitpoints = value;
      if (_myBow) { _myBow.HitpointValues = new Vector2Int(Hitpoints, _maxHitpoints); }
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
      _myBow.IsPulling = _isPullingBow;
    }
  }
  private bool _isPullingBow;

  public void Turn(bool left)
  {
    var t = transform.localEulerAngles;
    t.y += _ControllerTurnAmount * (left ? 1.0f : -1.0f);
    transform.localEulerAngles = t;
  }

  [Command]
  public void Cmd_SpawnArrow(Vector3 position, Vector3 forward, float pullAmount)
  {
    var arrow = Instantiate(_arrowPrefab);
    arrow.transform.position = position;
    arrow.transform.forward = forward;
    arrow.SourceCharacter = this;
    NetworkServer.Spawn(arrow.gameObject, NetworkServer.localConnection);
    var velocity = forward *
      Mathf.Lerp(
        App_Details.Instance.ARROW_SPEED_MIN,
        App_Details.Instance.ARROW_SPEED_MAX,
        pullAmount);
    arrow.Rpc_OnArrowCreated(velocity);
  }

  private float _ControllerTurnAmount;
  private bool _isLocalPc;

  private void Start()
  {
    _ControllerTurnAmount = App_Details.Instance.CONTROLLER_TURN_AMOUNT;
    Colliders = new List<Collider>();
    var bodyParts = new Transform[] { Head, Hand_Left, Hand_Right, Body };
    foreach (var bodyPart in bodyParts)
    {
      foreach (Transform t in bodyPart)
      {
        var c = t.GetComponent<Collider>();
        if (c) { Colliders.Add(c); }
      }
    }
    Hitpoints = _startingHitpoints;
    _isLocalPc = (NetworkClient.localPlayer == GetComponent<NetworkIdentity>());
    App_Functions.Instance.NetManager.AddListener_OnConnected(OnConnected);
  }

  private void OnConnected()
  {
    // Allow for up to ~10000 nonnetworked (preassigned) HitReactors and ~429k networked objects
    var reactorIdOffset = (GetComponent<NetworkIdentity>().netId + 1) * 10000;
    for (uint i = 0; i < HitReactors.Length; i++)
    {
      if (HitReactors[i].ReactorId == 0)
      {
        HitReactors[i].ReactorId = i + reactorIdOffset;
      }
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
      t += transform.forward * MovementInput.y * (IsDashing ? _dashSpeed : _speed) * Time.deltaTime;
      transform.localPosition = t;
    }
    if (MovementInput.x != 0)
    {
      var t = transform.localPosition;
      t += transform.right * MovementInput.x * (IsDashing ? _dashSpeed : _speed) * Time.deltaTime;
      transform.localPosition = t;
    }
  }
}
