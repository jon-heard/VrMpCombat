using Mirror;
using UnityEngine;

// Pc characters require extra handling to account for local vs remote
public class Pc : MonoBehaviour
{
  private void Start()
  {
    App_Functions.Instance.NetManager.AddListener_OnConnected(OnConnected);
  }

  private void OnConnected()
  {
    if (GetComponent<NetworkIdentity>().isLocalPlayer)
    {
      // NOTE: Need to add this (instead of having it by default) as having it applied at start
      // creates warning of multiple AudioListeners
      GetComponent<Character>().Head_UpDown.gameObject.AddComponent<AudioListener>();
    }
    else
    {
      // NOTE Need to have this by default (instead of adding it as needed) as it has custom set
      // fields
      Destroy(GetComponent<Character>().Head_UpDown.GetComponent<Camera>());
    }
  }
}
