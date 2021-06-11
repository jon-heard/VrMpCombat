using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAltTransform : MonoBehaviour
{
  public Vector3 Position;
  public Vector3 Rotation;

  private void Awake()
  {
    if (Application.isMobilePlatform)
    {
      transform.localPosition += Position;
      transform.localEulerAngles += Rotation;
    }
  }
}
