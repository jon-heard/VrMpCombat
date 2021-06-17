using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReactor_Character : HitReactor_AttachArrow
{
  public Character MyCharacter;
  public uint damage = 1;
  public bool DestroyLandedArrows;

  public override void OnHit(HitType type, GameObject source)
  {
    base.OnHit(type, source);
    RisingText.Create(
      MyCharacter.transform, new Vector3(0.0f, 1.25f, 0.0f), Vector3.zero, "-" + damage);
    MyCharacter.Hitpoints -= (int)damage;
    if (DestroyLandedArrows)
    {
      // NOTE: Only destroy arrow if it's in ArrowInstances.  If not then it should destroy itself
      // when it's done.
      if (App_Functions.Instance.ArrowInstances.Contains(source))
      {
        App_Functions.Instance.ArrowInstances.Remove(source);
        Destroy(source);
      }
    }
  }
}
