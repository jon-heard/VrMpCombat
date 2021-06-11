using UnityEngine;

public class HitReactor : MonoBehaviour
{
  public enum HitType { Arrow };
  public virtual void OnHit(HitType type, GameObject source)
  {
    Debug.Log(this.name + " hit with " + type);
  }
}
