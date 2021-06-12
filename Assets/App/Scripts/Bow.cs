using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
  [SerializeField] private Transform BowHand;
  [SerializeField] private Transform OtherHand;
  [SerializeField] private LineRenderer[] Lines;
  [SerializeField] private Transform ArrowPulled;
  [SerializeField] private NetSpawner Spawner;

  [NonSerialized] public bool IsPulling = false;

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
    _newArrowOffset = ArrowPulled.GetChild(0).localPosition.z;
    ArrowPulled.gameObject.SetActive(false);
    _initialLinePositions = new Vector3[Lines.Length];
    for (var i = 0; i < Lines.Length; i++)
    {
      _initialLinePositions[i] = Lines[i].GetPosition(1);
    }
    _otherHandDefaultPosition = OtherHand.localPosition;
  }

  private void Update()
  {
    if (IsPulling != _prevIsPulling)
    {
      if (IsPulling)
      {
        ArrowPulled.gameObject.SetActive(true);
      }
      else
      {
        // Shoot arrow
        var pullDistance = (BowHand.position - OtherHand.parent.position).magnitude;
        if (pullDistance > _minDistanceArrowRelease)
        {
          var arrowForward = ArrowPulled.forward;
          var arrowPosition = ArrowPulled.position + arrowForward * _newArrowOffset;
          var pullAmount =
            (pullDistance - _minDistanceArrowRelease) /
            (_maxDistanceBowPull - _minDistanceArrowRelease);
          Spawner.CmdSpawnFlyingArrow(arrowPosition, arrowForward, pullAmount);
        }
        // Reset everything
        ArrowPulled.gameObject.SetActive(false);
        transform.localRotation = _defaultRotation;
        OtherHand.localPosition = _otherHandDefaultPosition;
        for (var i = 0; i < Lines.Length; i++)
        {
          Lines[i].SetPosition(1, _initialLinePositions[i]);
        }
      }
      _prevIsPulling = IsPulling;
    }

    if (IsPulling)
    {
      transform.LookAt(OtherHand);
      ArrowPulled.LookAt(BowHand);
      foreach (var line in Lines)
      {
        line.SetPosition(1, line.transform.InverseTransformPoint(OtherHand.position));
      }
      var handDifference = (BowHand.position - OtherHand.parent.position);
      if (handDifference.sqrMagnitude > _maxDistanceBowPullSquared)
      {
        OtherHand.position = BowHand.position - handDifference.normalized * _maxDistanceBowPull;
        var t = OtherHand.localPosition;
        t += _otherHandDefaultPosition;
        OtherHand.localPosition = t;
      }
    }
  }
}
