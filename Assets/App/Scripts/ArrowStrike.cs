using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStrike : MonoBehaviour
{
  public float EmbedAmount = 0.01f;
  public Transform ArrowLandedPrefab;
  public Transform Base;
  public Collider MyCollider;

  [NonSerialized] public Character SourceCharacter;

  private float _arrowLength;

  private void Start()
  {
    _arrowLength = (Base.position - transform.parent.position).magnitude;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!transform.parent.GetComponent<NetworkIdentity>().hasAuthority) { return; }

    if (SourceCharacter.Colliders.Contains(other)) { return; }
    // Find where the arrow actually landed
    var hit = new RaycastHit();
    MyCollider.enabled = false;
    Physics.Raycast(Base.position, Base.forward, out hit);
    MyCollider.enabled = true;
    var distanceAdjust = (_arrowLength - hit.distance) - EmbedAmount;
    // Create landed version of the arrow
    var landed = GameObject.Instantiate(ArrowLandedPrefab, transform.parent.parent);
    landed.localPosition = transform.parent.localPosition - Base.forward * distanceAdjust;
    landed.localRotation = transform.parent.localRotation;
    App_Functions.Instance.ArrowInstances.Add(landed.gameObject);
    NetworkServer.Spawn(landed.gameObject, NetworkServer.localConnection);
    // Notify target that it has been shot
    other.GetComponent<HitReactor>()?.OnHit(HitReactor.HitType.Arrow, landed.gameObject);
    // Finish
    Destroy(transform.parent.gameObject);
  }
}
