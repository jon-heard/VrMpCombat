using Mirror;
using UnityEngine;

public class CharacterClass_Archer : CharacterClass
{
  public const string Flag_IsPulling = "isPulling";
  public const string Flag_IsTeleporting = "isTeleporting";

  [SerializeField] private Transform _arrowFist;
  [SerializeField] private Transform _bowFist;
  [SerializeField] private Transform _pulledArrow;
  [SerializeField] private GameObject _pulledArrowGlow;
  [SerializeField] private Arrow _arrowPrefab;
  [SerializeField] private ArrowTeleport _arrowTeleportPrefab;

  private float _const_maxDistanceBowPull;
  private float _const_maxDistanceBowPullSquared;
  private float _const_minDistanceArrowRelease;
  private float _createdArrowOffset;
  private Vector3 _arrowFistDefaultPosition;
  private bool _flagIsPulling; // Copy of CharacterClass flag, for efficiency

  protected override void SetFlag_Internal(string name, bool val)
  {
    if (_flags.ContainsKey(name) && _flags[name] == val) { return; }
    base.SetFlag_Internal(name, val);
    switch (name)
    {
      case Flag_IsPulling: ReactToFlagChange_IsPulling(val); break;
    }
  }

  protected void ReactToFlagChange_IsPulling(bool val)
  {
    if (!_character.Weapon || !(_character.Weapon is Item_Held_Weapon_Bow)) { return; }
    _flagIsPulling = val;
    if (val)
    {
      ((Item_Held_Weapon_Bow)_character.Weapon).PullHand = _arrowFist;
      _pulledArrow.gameObject.SetActive(true);
      _pulledArrowGlow.gameObject.SetActive(GetFlag(Flag_IsTeleporting));
    }
    else
    {
      if (_netIdentity.isLocalPlayer)
      {
        var pullDistance = (_bowFist.position - _arrowFist.position).magnitude;
        if (pullDistance > _const_minDistanceArrowRelease)
        {
          var arrowForward = _pulledArrow.forward;
          var arrowPosition = _pulledArrow.position + arrowForward * _createdArrowOffset;
          var pullAmount =
            (pullDistance - _const_minDistanceArrowRelease) /
            (_const_maxDistanceBowPull - _const_minDistanceArrowRelease);
          Cmd_SpawnArrow(GetFlag(Flag_IsTeleporting), arrowPosition, arrowForward, pullAmount);
        }
      }

      ((Item_Held_Weapon_Bow)_character.Weapon).PullHand = null;
      _pulledArrow.gameObject.SetActive(false);
      _arrowFist.localPosition = _arrowFistDefaultPosition;
    }
  }

  protected override void Start()
  {
    base.Start();
    _const_maxDistanceBowPull = App_Details.Instance.MAX_DISTANCE_BOWPULL;
    _const_maxDistanceBowPullSquared = Mathf.Pow(_const_maxDistanceBowPull, 2);
    _const_minDistanceArrowRelease = App_Details.Instance.MIN_DISTANCE_ARROWRELEASE;
    _createdArrowOffset = _pulledArrow.transform.GetChild(0).localPosition.z;
    _arrowFistDefaultPosition = _arrowFist.localPosition;
    _pulledArrow.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (_flagIsPulling)
    {
      _pulledArrow.LookAt(_bowFist);

      var handDifference = (_bowFist.position - _arrowFist.parent.position);
      if (handDifference.sqrMagnitude > _const_maxDistanceBowPullSquared)
      {
        _arrowFist.position = _bowFist.position - handDifference.normalized * _const_maxDistanceBowPull;
      }
    }
  }

  [Command]
  public void Cmd_SpawnArrow(bool IsTeleport, Vector3 position, Vector3 forward, float pullAmount)
  {
    var arrow = Instantiate(!IsTeleport ? _arrowPrefab : _arrowTeleportPrefab);
    arrow.transform.position = position;
    arrow.transform.forward = forward;
    NetworkServer.Spawn(arrow.gameObject, NetworkServer.localConnection);
    var velocity = forward *
      Mathf.Lerp(
        App_Details.Instance.ARROW_SPEED_MIN,
        App_Details.Instance.ARROW_SPEED_MAX,
        pullAmount);
    arrow.Rpc_OnArrowCreated(velocity, GetComponent<Character>());
  }
}
