using System;
using UnityEngine;

public class ArrowFlight : MonoBehaviour
{
  public ArrowStrike MyArrowStrike; // Used by "Bow" to tell arrow to ignore the hand shooting it
  [NonSerialized] public Vector3 Velocity;

  private float _gravity;
  private float _destructionDepth;
  private Vector3 _acceleration;

  private void Start()
  {
    _gravity = App_Details.Instance.GRAVITY;
    _destructionDepth = App_Details.Instance.ARROW_DESTRUCTION_DEPTH;
  }

  private void FixedUpdate()
  {
    // Destroy arrow if fallen into the abyss
    if (transform.localPosition.y < _destructionDepth)
    {
      GameObject.Destroy(gameObject);
      return;
    }

    _acceleration.y -= _gravity;
    Velocity += _acceleration;
    transform.localPosition += Velocity;
    transform.forward = Velocity.normalized;
  }
}
