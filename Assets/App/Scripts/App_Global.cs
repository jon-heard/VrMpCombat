using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public static class App_Global
{
  public static void RemoveComponents(Component[] components)
  {
    foreach (var component in components)
    {
      if (component == null)
      { }
      else if (component is Transform)
      {
        GameObject.Destroy(component.gameObject);
      }
      else
      {
        Component.Destroy(component);
      }
    }
  }

  public static string GetFullName(this Component z)
  {
    var result = z.name;
    while (z.transform.parent)
    {
      result = z.transform.parent.name + "/" + result;
      z = z.transform.parent;
    }
    return result;
  }
}
