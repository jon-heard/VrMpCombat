using Mirror;
using System.Collections.Generic;

public class CharacterClass : NetworkBehaviour
{
  public bool GetFlag(string name)
  {
    if (!_flags.ContainsKey(name)) { return false; }
    return _flags[name];
  }
  public void SetFlag(string name, bool val)
  {
    if (_netIdentity.isLocalPlayer)
    {
      SetFlag_Internal(name, val);
    }
    Cmd_SetFlag(name, val);
  }
  [Command]
  public void Cmd_SetFlag(string name, bool val)
  {
    Rpc_SetFlag(name, val);
  }
  [ClientRpc]
  public void Rpc_SetFlag(string name, bool val)
  {
    if (!_netIdentity.isLocalPlayer)
    {
      SetFlag_Internal(name, val);
    }
  }
  protected virtual void SetFlag_Internal(string name, bool val)
  {
    if (_flags.ContainsKey(name) && _flags[name] == val) { return; }
    _flags[name] = val;
  }

  protected Character _character;
  protected NetworkIdentity _netIdentity;
  protected Dictionary<string, bool> _flags = new Dictionary<string, bool>();

  protected virtual void Start()
  {
    _character = GetComponent<Character>();
    _netIdentity = GetComponent<NetworkIdentity>();
  }
}
