using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStrike : MonoBehaviour
{
  public float EmbedAmount = 0.01f;
  public Transform Base;
  public Collider MyCollider;

  [NonSerialized] public Character SourceCharacter;

  private float _arrowLength;
  private bool _landed;

  private void Start()
  {
    _arrowLength = (Base.position - transform.parent.position).magnitude;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!transform.parent.GetComponent<NetworkIdentity>().hasAuthority) { return; }
    if (SourceCharacter.Colliders.Contains(other)) { return; }
    if (_landed) { return; }
    _landed = true;
    // Find where the arrow actually landed
    var hit = new RaycastHit();
    MyCollider.enabled = false;
    Physics.Raycast(Base.position, Base.forward, out hit);
    MyCollider.enabled = true;
    other = hit.collider;
    var distanceAdjust = (_arrowLength - hit.distance) - EmbedAmount;
    // Get permissions to spawn the landed arrow
    // Create landed version of the arrow
    var position = transform.parent.localPosition - Base.forward * distanceAdjust;
    var rotation = transform.parent.localRotation;
    var otherHitReactor = other.GetComponent<HitReactor>();
    var netIdentity = transform.parent.GetComponent<NetworkIdentity>();
    netIdentity.RemoveClientAuthority();
    netIdentity.AssignClientAuthority(SourceCharacter.GetComponent<NetworkIdentity>().connectionToClient);
    SourceCharacter.Rpcs.CmdSpawnLandedArrow(
      position, rotation, otherHitReactor ? otherHitReactor.ReactorId : 0);
    // Finish
    Destroy(transform.parent.gameObject);
  }
}
