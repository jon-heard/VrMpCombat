using System;
using UnityEngine.Events;

namespace Common
{
  [Serializable]
  public class UnityEventParameterized<T> : UnityEvent<T>
  {
    public void InvokeWithParameter(T parameter)
    {
      var count = GetPersistentEventCount();
      for (var i = 0; i < count; i++)
      {
        var target = GetPersistentTarget(i);
        if (target == null) { continue; }
        var methodName = GetPersistentMethodName(i);
        target.GetType().GetMethod(methodName).Invoke(target, new object[] { parameter });
      }
    }
  }
}
