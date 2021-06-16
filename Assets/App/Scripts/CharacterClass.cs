
using Mirror;

public class CharacterClass : NetworkBehaviour
{
  protected Character _character;
  protected NetworkIdentity _netIdentity;

  protected virtual void Start()
  {
    _character = GetComponent<Character>();
    _netIdentity = GetComponent<NetworkIdentity>();
  }

  public bool IsWeaponActivated { get; private set; }

  public void SetIsWeaponActivated(bool val)
  {
    if (_netIdentity.isLocalPlayer)
    {
      SetIsWeaponActivated_Internal(val);
    }
    Cmd_SetIsWeaponActivated(val);
  }
  [Command]
  public void Cmd_SetIsWeaponActivated(bool val)
  {
    Rpc_SetIsWeaponActivated(val);
  }
  [ClientRpc]
  public void Rpc_SetIsWeaponActivated(bool val)
  {
    if (!_netIdentity.isLocalPlayer)
    {
      SetIsWeaponActivated_Internal(val);
    }
  }
  protected virtual void SetIsWeaponActivated_Internal(bool val)
  {
    if (val == IsWeaponActivated) { return; }
    IsWeaponActivated = val;
  }
}
