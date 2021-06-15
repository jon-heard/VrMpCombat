using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReactor : MonoBehaviour
{
  public uint ReactorId = 0;

  public enum HitType { Arrow };
  public virtual void OnHit(HitType type, GameObject source)
  {
    Debug.Log(this.name + " hit with " + type);
  }

  public static uint NextUnassignedId
  {
    get
    {
      uint result = 1;
      while (HitReactor._instances.ContainsKey(result))
      {
        result++;
      }
      return result;
    }
  }

  public static HitReactor GetHitReactorById(uint id)
  {
    if (_instances.ContainsKey(id))
    {
      return _instances[id];
    }
    else
    {
      return null;
    }
  }

  public void Start()
  {
    App_Functions.Instance.NetManager.AddListener_OnConnected(OnConnected);
  }

  private void OnConnected()
  {
    StartCoroutine(OnConnectedCoroutine());
  }
  private IEnumerator OnConnectedCoroutine()
  {
    yield return null;

    if (ReactorId == 0)
    {
      Debug.LogError(
        "HitReactor not assigned an id: '" + this.GetFullName() + "'");
      yield break;
    }

    if (HitReactor._instances.ContainsKey(ReactorId))
    {
      if (HitReactor._instances[ReactorId] != this)
      {
        uint newId = HitReactor.NextUnassignedId;
        Debug.LogError("HitReactor id collision: id #" + ReactorId + ": between '" + this.name + "' and '" + HitReactor._instances[ReactorId].name + "'.  Giving '" + this.name + "' the new id of " + newId);
        ReactorId = newId;
      }
    }
    else
    {
      HitReactor._instances.Add(ReactorId, this);
    }
  }

  private static Dictionary<uint, HitReactor> _instances = new Dictionary<uint, HitReactor>();
}
