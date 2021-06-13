using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReactor_Armor : HitReactor_AttachArrow
{
  public uint ArmorHealth = 1;
  public Character MyCharacter;

  public override void OnHit(HitType type, GameObject source)
  {
    base.OnHit(type, source);
    if (ArmorHealth > 0)
    {
      ArmorHealth--;
    }
    else
    {
      Destroy(this.gameObject);
    }
    RisingText.Create(
      MyCharacter.transform, new Vector3(0.0f, 1.25f, 0.0f), Vector3.zero,
      "", App_Resources.Instance.RisingTextIcon_Armor);
  }
}
