using Mirror;
using System;
using UnityEngine;

public class ArrowFlight : MonoBehaviour
{
  public ArrowStrike MyArrowStrike;
  [NonSerialized] public Vector3 Velocity;

  private float _gravity;
  private float _destructionDepth;
  private Vector3 _acceleration;

  private void Start()
  {
    _gravity = App_Details.Instance.GRAVITY;
    _destructionDepth = App_Details.Instance.ARROW_DESTRUCTION_DEPTH;

    if (!GetComponent<NetworkIdentity>().hasAuthority) { enabled = false; }
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
