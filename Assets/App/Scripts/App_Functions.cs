using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class App_Functions : Singleton<App_Functions>
{
  [SerializeField] private bool BeHost = true;
  [SerializeField] private string HostIP = "192.168.0.16";
  [SerializeField] private Animation DamageOverlay;

  [NonSerialized] public List<GameObject> ArrowInstances = new List<GameObject>();

  public void ClearArrows()
  {
    foreach (var instance in ArrowInstances)
    {
      GameObject.Destroy(instance);
    }
    ArrowInstances.Clear();
  }

  public void FlashDamageOverlay()
  {
    DamageOverlay.Rewind();
    DamageOverlay.Play();
  }

  private bool _vrStarted = false;

  private void Start()
  {
    if (App_Details.Instance.IN_VR)
    {
      //StartCoroutine(StartVr());
    }
    var net = GetComponent<NetworkManager>();
    net.networkAddress = HostIP;
    if (BeHost) { net.StartHost(); } else { net.StartClient(); }
  }

  private void OnDestroy()
  {
    //if (_vrStarted) { StopVr(); }
  }

  private IEnumerator StartVr()
  {
    yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
    if (XRGeneralSettings.Instance.Manager.activeLoader == null)
    {
      Debug.LogError("Initializing VR Failed. Check Editor or Player log for details.");
    }
    else
    {
      XRGeneralSettings.Instance.Manager.StartSubsystems();
      yield return null;
    }
  }

  private void StopVr()
  {
    if (XRGeneralSettings.Instance.Manager.isInitializationComplete)
    {
      XRGeneralSettings.Instance.Manager.StopSubsystems();
      Camera.main.ResetAspect();
      XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    }
  }
}
