using UnityEngine;
using UnityEngine.Events;

namespace Common
{
  public class EventExternalIzer_OnTriggerEnter : MonoBehaviour
  {
    public UnityEventParameterized<Collider> OnTriggerEnterExternalized;

    private void OnTriggerEnter(Collider other)
    {
      OnTriggerEnterExternalized.InvokeWithParameter(other);
    }
  }
}
