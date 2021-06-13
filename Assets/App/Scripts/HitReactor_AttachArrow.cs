using UnityEngine;

public class HitReactor_AttachArrow : HitReactor
{
  public Transform ToAttachTo;

  public override void OnHit(HitType type, GameObject source)
  {
    if (type == HitType.Arrow)
    {
      if (ToAttachTo == null) { ToAttachTo = transform; }
      source.transform.parent = ToAttachTo;
    }
  }
}
