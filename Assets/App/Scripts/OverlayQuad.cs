using UnityEngine;

public class OverlayQuad : MonoBehaviour
{
  private void Start()
  {
    GetComponent<MeshFilter>().mesh.bounds =
      new Bounds(Vector3.zero, Vector3.one * float.MaxValue);
  }
}
