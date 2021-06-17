using UnityEngine;

namespace Common
{
  public class EventExternalizer_OnTriggerEnter : MonoBehaviour
  {
    public UnityEventParameterized<Collider> OnTriggerEnterExternalized;

    private void OnTriggerEnter(Collider other)
    {
      OnTriggerEnterExternalized.InvokeWithParameter(other);
    }
  }
}
