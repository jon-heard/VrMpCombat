using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRpcs : NetworkBehaviour
{
  [SerializeField] private ArrowFlight _flyingArrowPrefab;
  [SerializeField] private Transform _landedrrowPrefab;
  [SerializeField] private Character _character;

  [Command]
  public void CmdSpawnFlyingArrow(Vector3 position, Vector3 forward, float pullAmount)
  {
    var arrow = Instantiate(_flyingArrowPrefab);
    arrow.transform.position = position;
    arrow.transform.forward = forward;
    arrow.Velocity =
      forward *
      Mathf.Lerp(App_Details.Instance.ARROW_VELOCITY_MIN, App_Details.Instance.ARROW_VELOCITY_MAX, pullAmount);
    arrow.MyArrowStrike.SourceCharacter = _character;
    NetworkServer.Spawn(arrow.gameObject, NetworkServer.localConnection);
  }

  [Command(requiresAuthority = false)]
  public void CmdSpawnLandedArrow(Vector3 position, Quaternion rotation, uint TargetReactorId)
  {
    var landed = GameObject.Instantiate(_landedrrowPrefab);
    landed.localPosition = position;
    landed.localRotation = rotation;
    App_Functions.Instance.ArrowInstances.Add(landed.gameObject);
    NetworkServer.Spawn(landed.gameObject, NetworkServer.localConnection);
    if (TargetReactorId != 0)
    {
      RpcNotifyHit(
        TargetReactorId, HitReactor.HitType.Arrow, landed.gameObject);
    }
  }

  [ClientRpc]
  public void RpcNotifyHit(uint targetReactorId, HitReactor.HitType hitType, GameObject hitSource)
  {
    var targetReactor = HitReactor.GetHitReactorById(targetReactorId);
    if (targetReactor != null)
    {
      targetReactor?.OnHit(hitType, hitSource);
    }
    else
    {
      Debug.LogError("CharacterRpcs.RpcNotifyHit: invalid reactor id given: " + targetReactorId);
    }
  }
}
