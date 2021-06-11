using System;
using System.Collections.Generic;
using UnityEngine;

public class App_Functions : Singleton<App_Functions>
{
  [NonSerialized] public List<GameObject> ArrowInstances = new List<GameObject>();

  public void ClearArrows()
  {
    foreach (var instance in ArrowInstances)
    {
      GameObject.Destroy(instance);
    }
    ArrowInstances.Clear();
  }
}
