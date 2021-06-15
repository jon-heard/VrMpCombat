using Mirror;
using UnityEngine;

public class Pc : MonoBehaviour
{
  [SerializeField] private Character _character;

  private void Start()
  {
    App_Functions.Instance.NetManager.AddListener_OnConnected(OnConnected);
  }

  private void OnConnected()
  {
    if (GetComponent<NetworkIdentity>().isLocalPlayer)
    {
      _character.Head_UpDown.gameObject.AddComponent<AudioListener>();
    }
    else
    {
      Destroy(_character.Head_UpDown.GetComponent<Camera>());
    }
  }
}
