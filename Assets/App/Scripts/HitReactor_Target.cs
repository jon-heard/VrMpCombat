using UnityEngine;

public class HitReactor_Target : HitReactor
{
  public override void OnHit(HitType type, GameObject source)
  {
    Debug.Log(this.transform.parent.name + " hit with " + type);
  }
}
