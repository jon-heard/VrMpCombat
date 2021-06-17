using Mirror;
using System;
using System.Collections;
using UnityEngine;

public class Arrow : NetworkBehaviour
{
  [SerializeField] private Component[] _toRemoveIfNotServer;
  [SerializeField] protected Component[] _toRemovePostFlying;
  [SerializeField] private Component[] _toRemovePostAnimation;
  [SerializeField] private Transform _nock;
  [SerializeField] private Collider _collider;

  [NonSerialized] public Character SourceCharacter;

  [ClientRpc]
  public virtual void Rpc_OnArrowCreated(Vector3 velocity, Character sourceCharacter)
  {
    _velocity = velocity;
    SourceCharacter = sourceCharacter;
    if (!isServer)
    {
      App_Global.RemoveComponents(_toRemoveIfNotServer);
    }
    // NOTE: Need geometry disabled until after removing non-localplayer components, to prevent
    // unwanted OnGeometryTriggerEnter calls
    _collider.gameObject.SetActive(true);
    _coroutine_fixedUpdate_WhileInFlyingState = StartCoroutine(FixedUpdate_WhileInFlyingState());
  }

  public void OnGeometryTriggerEnter(Collider other)
  {
    // Don't shoot yourself
    if (SourceCharacter.Colliders.Contains(other)) { return; }
    // Block repeat triggerings on single arrow
    if (_isTriggered) { return; }
    _isTriggered = true;
    // Find where the arrow actually landed
    var hit = new RaycastHit();
    foreach (var collider in SourceCharacter.Colliders) { if (collider != null) { collider.enabled = false; } }
    _collider.enabled = false;
    Physics.Raycast(_nock.position, _nock.forward, out hit);
    _collider.enabled = true;
    foreach (var collider in SourceCharacter.Colliders) { if (collider != null) { collider.enabled = true; } }
    other = hit.collider;
    var distanceAdjust = (_arrowLength - hit.distance) - _const_embedDepth;
    // Find HitReactor to react to collision
    var hitReactorId = other.GetComponent<HitReactor>()?.ReactorId ?? 0;
    // Reposition to actual arrow landing setup
    Rpc_OnArrowLanded(transform.localPosition - _nock.forward * distanceAdjust, hitReactorId);
  }

  [ClientRpc]
  public virtual void Rpc_OnArrowLanded(Vector3 finalPosition, uint hitReactorId)
  {
    StopCoroutine(_coroutine_fixedUpdate_WhileInFlyingState);
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

  protected Vector3 _velocity;
  private Vector3 _acceleration;
  private float _arrowLength;
  private bool _isTriggered = false;
  private Coroutine _coroutine_fixedUpdate_WhileInFlyingState;

  private float _const_gravity;
  private float _const_destructionDepth;
  private float _const_embedDepth;

  private void Awake()
  {
    // NOTE: Need to enable geometry only after removing non-localplayer components, or we get
    // unwanted OnGeometryTriggerEnter calls
    _collider.gameObject.SetActive(false);
  }

  private void Start()
  {
    _const_gravity = App_Details.Instance.GRAVITY;
    _const_destructionDepth = App_Details.Instance.ARROW_DESTRUCTION_DEPTH;
    _const_embedDepth = App_Details.Instance.ARROW_EMBED_DEPTH;
    _arrowLength = (_nock.position - transform.position).magnitude;
    App_Functions.Instance.ArrowInstances.Add(gameObject);
  }

  protected IEnumerator FixedUpdate_WhileInFlyingState()
  {
    while (true) // Stopped by "StopCoroutine()" when geometry is triggered
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
