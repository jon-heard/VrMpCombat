
using UnityEngine;

public class CharacterController_PcLocal : CharacterController
{
  protected App_Input _input;
  protected float _const_maxDistanceTriggerBowPullSquared;

  protected override void Start()
  {
    base.Start();
    _input = new App_Input();
    _input.Enable();

    _const_maxDistanceTriggerBowPullSquared =
      Mathf.Pow(App_Details.Instance.MAX_DISTANCE_TRIGGER_BOWPULL, 2);
  }
}
