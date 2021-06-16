using UnityEngine;

public class Item_Held_Weapon : Item_Held
{
  [SerializeField] private TextMesh _hitpointDisplay;

  public Vector2Int HitpointValues
  {
    get { return _hitpointValues; }
    set
    {
      if (value == _hitpointValues) { return; }
      _hitpointValues = value;
      var const_hpColor = App_Details.Instance.COLOR_HITPOINT_DISPLAY;
      var const_hpEmptyColor = App_Details.Instance.COLOR_HITPOINT_DISPLAY_EMPTY;
      var _hitpointDisplayText = "";
      for (var i = 0; i < _hitpointValues.y; i++)
      {
        var color = (i < _hitpointValues.x) ? const_hpEmptyColor : const_hpColor;
        _hitpointDisplayText =
          "<color=#" + color + ">¢</color>" + (i > 0 ? "\n" : "") + _hitpointDisplayText;
      }
      _hitpointDisplay.text = _hitpointDisplayText;
    }
  }
  private Vector2Int _hitpointValues;
}
