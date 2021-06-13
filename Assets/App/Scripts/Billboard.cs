using System;
using UnityEngine;

public class Billboard : MonoBehaviour
{
  private void OnEnable()
  {
    Camera.onPreRender += OnPrerender;
  }

  private void OnDisable()
  {
    Camera.onPreRender -= OnPrerender;
  }

  private void OnPrerender(Camera camera)
  {
    transform.LookAt(camera.transform);
  }
}
