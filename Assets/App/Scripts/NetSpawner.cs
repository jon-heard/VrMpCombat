using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class NetSpawner : NetworkBehaviour
{
  [SerializeField] private ArrowFlight _flyingArrowPrefab;
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

  private List<Collider> _toIgnore = new List<Collider>();
}
