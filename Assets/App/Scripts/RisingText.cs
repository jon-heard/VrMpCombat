using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingText : MonoBehaviour
{
  public TextMesh Text;
  public SpriteRenderer IconRenderer;

  public static void Create(
    Transform parent, Vector3 position, Vector3 rotation, string text = "-1", Sprite icon = null)
  {
    var newRisingText = Instantiate(App_Resources.Instance.RisingTextPrefab, parent);
    newRisingText.transform.localPosition = position;
    newRisingText.transform.localEulerAngles = rotation;
    newRisingText.Text.text = text;
    newRisingText.IconRenderer.sprite = icon ?? App_Resources.Instance.RisingTextIcon_Default;
  }

  public void Cleanup()
  {
    Destroy(this.gameObject);
  }
}
