
using UnityEngine;

public class CharacterController_PcLocal : CharacterController
{
  protected App_Input _input;
  protected float _maxDistanceTriggerBowPullSquared;

  protected override void Start()
  {
    base.Start();
    _input = new App_Input();
    _input.Enable();

    _maxDistanceTriggerBowPullSquared =
      Mathf.Pow(App_Details.Instance.MAX_DISTANCE_TRIGGER_BOWPULL, 2);
  }
}
