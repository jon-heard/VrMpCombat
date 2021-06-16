using Mirror;
using UnityEngine;

public class CharacterClass_Archer : CharacterClass
{
  [SerializeField] private Transform _arrowFist;
  [SerializeField] private Transform _bowFist;
  [SerializeField] private Transform _pulledArrow;
  [SerializeField] private Arrow _arrowPrefab;

  protected override void SetIsWeaponActivated_Internal(bool val)
  {
    if (val == IsWeaponActivated) { return; }
    if (!_character.Weapon || !(_character.Weapon is Item_Held_Weapon_Bow)) { return; }
    base.SetIsWeaponActivated_Internal(val);
    if (val)
    {
      ((Item_Held_Weapon_Bow)_character.Weapon).PullHand = _arrowFist;
      _pulledArrow.gameObject.SetActive(true);
    }
    else
    {
      if (_netIdentity.isLocalPlayer)
      {
        var pullDistance = (_bowFist.position - _arrowFist.position).magnitude;
        if (pullDistance > _const_minDistanceArrowRelease)
        {
          var arrowForward = _pulledArrow.forward;
          var arrowPosition = _pulledArrow.position + arrowForward * _newArrowOffset;
          var pullAmount =
            (pullDistance - _const_minDistanceArrowRelease) /
            (_const_maxDistanceBowPull - _const_minDistanceArrowRelease);
          Cmd_SpawnArrow(arrowPosition, arrowForward, pullAmount);
        }
      }

      ((Item_Held_Weapon_Bow)_character.Weapon).PullHand = null;
      _pulledArrow.gameObject.SetActive(false);
      _arrowFist.localPosition = _arrowFistDefaultPosition;
    }
  }

  private float _const_maxDistanceBowPull;
  private float _const_maxDistanceBowPullSquared;
  private float _const_minDistanceArrowRelease;
  private float _newArrowOffset;
  private Vector3 _arrowFistDefaultPosition;

  protected override void Start()
  {
    base.Start();
    _const_maxDistanceBowPull = App_Details.Instance.MAX_DISTANCE_BOWPULL;
    _const_maxDistanceBowPullSquared = Mathf.Pow(_const_maxDistanceBowPull, 2);
    _const_minDistanceArrowRelease = App_Details.Instance.MIN_DISTANCE_ARROWRELEASE;
    _newArrowOffset = _pulledArrow.transform.GetChild(0).localPosition.z;
    _arrowFistDefaultPosition = _arrowFist.localPosition;
    _pulledArrow.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (IsWeaponActivated)
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
  public void Cmd_SpawnArrow(Vector3 position, Vector3 forward, float pullAmount)
  {
    var arrow = Instantiate(_arrowPrefab);
    arrow.transform.position = position;
    arrow.transform.forward = forward;
    arrow.SourceCharacter = GetComponent<Character>();
    NetworkServer.Spawn(arrow.gameObject, NetworkServer.localConnection);
    var velocity = forward *
      Mathf.Lerp(
        App_Details.Instance.ARROW_SPEED_MIN,
        App_Details.Instance.ARROW_SPEED_MAX,
        pullAmount);
    arrow.Rpc_OnArrowCreated(velocity);
  }
}
