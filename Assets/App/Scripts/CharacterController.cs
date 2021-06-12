using Mirror;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  protected Character _character;

  protected virtual void Start()
  {
    _character = GetComponent<Character>();
    if (!GetComponent<NetworkIdentity>().hasAuthority) { enabled = false; }
  }
}
