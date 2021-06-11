using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStrike : MonoBehaviour
{
  public Transform ArrowLandedPrefab;

  [NonSerialized] public List<Collider> ToIgnore;

  private void OnTriggerEnter(Collider other)
  {
    if (ToIgnore.Contains(other)) { return; }
    Debug.Log("Arrow hit: " + other.name);
    var landed = GameObject.Instantiate(ArrowLandedPrefab, transform.parent.parent);
    landed.localPosition = transform.parent.localPosition;
    landed.localRotation = transform.parent.localRotation;
    Destroy(transform.parent.gameObject);
    App_Functions.Instance.ArrowInstances.Add(landed.gameObject);
    other.GetComponent<HitReactor>()?.OnHit(HitReactor.HitType.Arrow, landed.gameObject);
  }
}
