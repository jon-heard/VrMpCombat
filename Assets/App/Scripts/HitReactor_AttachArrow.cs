using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReactor_AttachArrow : HitReactor
{
  public Transform ToAttachTo;

  public override void OnHit(HitType type, GameObject source)
  {
    if (type == HitType.Arrow)
    {
      source.transform.parent = ToAttachTo;
    }
  }
}
