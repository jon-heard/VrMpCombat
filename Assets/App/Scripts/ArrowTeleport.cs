using Mirror;
using System;
using System.Collections;
using UnityEngine;

public class ArrowTeleport : Arrow
{
  [ClientRpc]
  public override void Rpc_OnArrowCreated(Vector3 velocity, Character sourceCharacter)
  {
    base.Rpc_OnArrowCreated(velocity, sourceCharacter);
    _velocity *= App_Details.Instance.ARROW_TELEPORT_SPEED_MODIFIER;
    // Remove arrow from the arrow instances collection.  teleport arrows auto-remove themselves
    // when finished, and don't work right (i.e. don't teleport) if removed externally
    App_Functions.Instance.ArrowInstances.Remove(gameObject);
  }

  [ClientRpc]
  public override void Rpc_OnArrowLanded(Vector3 finalPosition, uint hitReactorId)
  {
    base.Rpc_OnArrowLanded(finalPosition, hitReactorId);
    StartCoroutine(TeleportPc());
  }

  private IEnumerator TeleportPc()
  {
    var source = SourceCharacter.transform.position;
    var destination = transform.position;
    var teleportFrameCount = App_Details.Instance.TELEPORT_FRAME_COUNT;
    destination.y = source.y;
    var frameCounter = 0;
    do
    {
      yield return new WaitForFixedUpdate();
      SourceCharacter.transform.position =
        Vector3.Lerp(source, destination, (float)frameCounter / teleportFrameCount);
      frameCounter++;
    }
    while (frameCounter <= teleportFrameCount);
    Destroy(gameObject);
  }
}
