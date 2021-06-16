using Mirror;
using System;
using System.Collections;
using UnityEngine;

public class Arrow : NetworkBehaviour
{
  [SerializeField] private Component[] _toRemoveIfNotServer;
  [SerializeField] private Component[] _toRemovePostFlying;
  [SerializeField] private Component[] _toRemovePostAnimation;
  [SerializeField] private Transform _nock;
  [SerializeField] private Collider _collider;

  [NonSerialized] public Character SourceCharacter;

  [ClientRpc]
  public void Rpc_OnArrowCreated(Vector3 velocity)
  {
    _velocity = velocity;
    StartCoroutine(FixedUpdate_WhileInFlyingState());
  }

  public void OnGeometryTriggerEnter(Collider other)
  {
    if (SourceCharacter.Colliders.Contains(other)) { return; }
    // Find where the arrow actually landed
    var hit = new RaycastHit();
    _collider.enabled = false;
    Physics.Raycast(_nock.position, _nock.forward, out hit);
    _collider.enabled = true;
    other = hit.collider;
    var distanceAdjust = (_arrowLength - hit.distance) - _const_embedDepth;
    // Notify HitReactor setup
    var hitReactorId = other.GetComponent<HitReactor>()?.ReactorId ?? 0;
    // Reposition to actual arrow landing setup
    Rpc_OnArrowLanded(transform.localPosition - _nock.forward * distanceAdjust, hitReactorId);
  }

  [ClientRpc]
  public void Rpc_OnArrowLanded(Vector3 finalPosition, uint hitReactorId)
  {
    StopAllCoroutines();
    App_Global.RemoveComponents(_toRemovePostFlying);
    transform.position = finalPosition;
    GetComponent<Animation>().Play();
    if (hitReactorId != 0)
    {
      var hitReactor = HitReactor.GetHitReactorById(hitReactorId);
      if (hitReactor == null)
      {
        Debug.LogError("CharacterRpcs.RpcNotifyHit: invalid reactor id given: " + hitReactorId);
        return;
      }
      hitReactor.OnHit(HitReactor.HitType.Arrow, gameObject);
    }
  }

  public void OnArrowFinished()
  {
    App_Global.RemoveComponents(_toRemovePostAnimation);
  }

  private Vector3 _velocity; // Public as it's set externally on instantiation
  private Vector3 _acceleration;
  private float _arrowLength;

  private float _const_gravity;
  private float _const_destructionDepth;
  private float _const_embedDepth;

  private void Start()
  {
    _const_gravity = App_Details.Instance.GRAVITY;
    _const_destructionDepth = App_Details.Instance.ARROW_DESTRUCTION_DEPTH;
    _const_embedDepth = App_Details.Instance.ARROW_EMBED_DEPTH;
    _arrowLength = (_nock.position - transform.position).magnitude;
    if (!isServer)
    {
      App_Global.RemoveComponents(_toRemoveIfNotServer);
    }
    App_Functions.Instance.ArrowInstances.Add(gameObject);
  }

  private IEnumerator FixedUpdate_WhileInFlyingState()
  {
    while (true) // Stopped by "StopAllCoroutines()" at end of flying
    {
      yield return new WaitForFixedUpdate();
      // Destroy if flown off map edge
      if (transform.localPosition.y < _const_destructionDepth)
      {
        App_Functions.Instance.ArrowInstances.Remove(gameObject);
        GameObject.Destroy(gameObject);
        yield break;
      }
      _acceleration.y -= _const_gravity;
      _velocity += _acceleration;
      transform.localPosition += _velocity;
      transform.forward = _velocity.normalized;
    }
  }
}
