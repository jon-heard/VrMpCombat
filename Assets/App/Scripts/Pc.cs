using Mirror;
using UnityEngine;

public class Pc : MonoBehaviour
{
  [SerializeField] private Character _character;

  private void Start()
  {
    var netIdentity = GetComponent<NetworkIdentity>();
    if (netIdentity == null || netIdentity.hasAuthority) { return; }
    Destroy(_character.Head_UpDown.GetComponent<Camera>());
    Destroy(_character.Head_UpDown.GetComponent<AudioListener>());
  }
}
