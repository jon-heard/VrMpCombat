using UnityEngine;
using UnityEngine.Events;

public class EventExternalIzer_OnTriggerEnter : MonoBehaviour
{
  public Helper_UnityEventParameterized<Collider> OnTriggerEnterExternalized;

  private void OnTriggerEnter(Collider other)
  {
    OnTriggerEnterExternalized.InvokeWithParameter(other);
  }
}
