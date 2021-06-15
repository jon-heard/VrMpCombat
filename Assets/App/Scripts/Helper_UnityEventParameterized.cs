using System;
using UnityEngine.Events;

[Serializable]
public class Helper_UnityEventParameterized<T> : UnityEvent<T>
{
  public void InvokeWithParameter(T parameter)
  {
    var count = GetPersistentEventCount();
    for (var i = 0; i < count; i++)
    {
      var target = GetPersistentTarget(i);
      var methodName = GetPersistentMethodName(i);
      target.GetType().GetMethod(methodName).Invoke(target, new object[] { parameter });
    }
  }
}
