using UnityEngine;

public class HitReactor_Target : HitReactor
{
  public override void OnHit(HitType type, GameObject source)
  {
    RisingText.Create(transform.parent, new Vector3(0.0f, 2.0f, 0.0f), Vector3.zero);
  }
}
