
using Mirror;
using System;

public class NetworkManager_VrMpCombat : NetworkManager
{
  public void AddListener_OnConnected(Action listener)
  {
    if (_hasConnected)
    {
      listener.Invoke();
    }
    else
    {
      _onConnected += listener;
    }
  }

  public override void OnClientConnect(NetworkConnection conn)
  {
    base.OnClientConnect(conn);
    _onConnected.Invoke();
    _hasConnected = true;
  }

  private Action _onConnected;
  private bool _hasConnected;
}
