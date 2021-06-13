using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
  [SerializeField] private Transform _bowHand;
  [SerializeField] private Transform _otherHand;
  [SerializeField] private LineRenderer[] _lines;
  [SerializeField] private Transform _arrowPulled;
  [SerializeField] private Character _character;
  [SerializeField] private TextMesh _hitpointDisplay;

  [NonSerialized] public bool IsPulling = false;

  public Vector2Int HitpointValues
  {
    get { return _hitpointValues; }
    set
    {
      if (value == _hitpointValues) { return; }
      _hitpointValues = value;
      var hpColor = App_Details.Instance.COLOR_HITPOINT_DISPLAY;
      var hpEmptyColor = App_Details.Instance.COLOR_HITPOINT_DISPLAY_EMPTY;
      var _hitpointDisplayText = "";
      for (var i = 0; i < _hitpointValues.y; i++)
      {
        var color = (i < _hitpointValues.x) ? hpEmptyColor : hpColor;
        _hitpointDisplayText =
          "<color=#" + color  + ">¢</color>" + (i > 0 ? "\n" : "") + _hitpointDisplayText;
      }
      _hitpointDisplay.text = _hitpointDisplayText;
    }
  }
  private Vector2Int _hitpointValues;

  private Quaternion _defaultRotation;
  private bool _prevIsPulling = false;
  private float _newArrowOffset;
  private float _maxDistanceBowPull;
  private float _maxDistanceBowPullSquared;
  private float _minDistanceArrowRelease;
  private Vector3[] _initialLinePositions;
  private Vector3 _otherHandDefaultPosition;

  private void Start()
  {
    _defaultRotation = transform.localRotation;
    _maxDistanceBowPull = App_Details.Instance.MAX_DISTANCE_BOWPULL;
    _maxDistanceBowPullSquared = Mathf.Pow(_maxDistanceBowPull, 2);
    _minDistanceArrowRelease = App_Details.Instance.MIN_DISTANCE_ARROWRELEASE;
    _newArrowOffset = _arrowPulled.GetChild(0).localPosition.z;
    _arrowPulled.gameObject.SetActive(false);
    _initialLinePositions = new Vector3[_lines.Length];
    for (var i = 0; i < _lines.Length; i++)
    {
      _initialLinePositions[i] = _lines[i].GetPosition(1);
    }
    _otherHandDefaultPosition = _otherHand.localPosition;
  }

  private void Update()
  {
    if (IsPulling != _prevIsPulling)
    {
      if (IsPulling)
      {
        _arrowPulled.gameObject.SetActive(true);
      }
      else
      {
        // Shoot arrow
        var pullDistance = (_bowHand.position - _otherHand.parent.position).magnitude;
        if (pullDistance > _minDistanceArrowRelease)
        {
          var arrowForward = _arrowPulled.forward;
          var arrowPosition = _arrowPulled.position + arrowForward * _newArrowOffset;
          var pullAmount =
            (pullDistance - _minDistanceArrowRelease) /
            (_maxDistanceBowPull - _minDistanceArrowRelease);
          _character.Rpcs.CmdSpawnFlyingArrow(arrowPosition, arrowForward, pullAmount);
        }
        // Reset everything
        _arrowPulled.gameObject.SetActive(false);
        transform.localRotation = _defaultRotation;
        _otherHand.localPosition = _otherHandDefaultPosition;
        for (var i = 0; i < _lines.Length; i++)
        {
          _lines[i].SetPosition(1, _initialLinePositions[i]);
        }
      }
      _prevIsPulling = IsPulling;
    }

    if (IsPulling)
    {
      transform.LookAt(_otherHand);
      _arrowPulled.LookAt(_bowHand);
      foreach (var line in _lines)
      {
        line.SetPosition(1, line.transform.InverseTransformPoint(_otherHand.position));
      }
      var handDifference = (_bowHand.position - _otherHand.parent.position);
      if (handDifference.sqrMagnitude > _maxDistanceBowPullSquared)
      {
        _otherHand.position = _bowHand.position - handDifference.normalized * _maxDistanceBowPull;
        var t = _otherHand.localPosition;
        t += _otherHandDefaultPosition;
        _otherHand.localPosition = t;
      }
    }
  }
}
