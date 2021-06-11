using UnityEngine;
using UnityEngine.Events;

public class HitReactor_Button : HitReactor
{
  public UnityEvent HitEvent;

  public override void OnHit(HitType type, GameObject source)
  {
    HitEvent.Invoke();
  }
}
