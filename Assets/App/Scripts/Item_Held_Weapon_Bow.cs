using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Item_Held_Weapon_Bow : Item_Held_Weapon
{
  [SerializeField] private LineRenderer[] _lines;

  [NonSerialized] public Transform PullHand;
  private Transform _prevPullHand;

  private Quaternion _defaultRotation;
  private Vector3[] _initialLinePositions;

  private void Start()
  {
    _defaultRotation = transform.localRotation;
    _initialLinePositions = new Vector3[_lines.Length];
    for (var i = 0; i < _lines.Length; i++)
    {
      _initialLinePositions[i] = _lines[i].GetPosition(1);
    }
  }

  private void Update()
  {
    if (PullHand != _prevPullHand)
    {
      // Reset state to default (non-pulling)
      if (!PullHand)
      {
        transform.localRotation = _defaultRotation;
        for (var i = 0; i < _lines.Length; i++)
        {
          _lines[i].SetPosition(1, _initialLinePositions[i]);
        }
      }
      _prevPullHand = PullHand;
    }

    if (PullHand)
    {
      transform.LookAt(PullHand);
      foreach (var line in _lines)
      {
        line.SetPosition(1, line.transform.InverseTransformPoint(PullHand.position));
      }
    }
  }
}
