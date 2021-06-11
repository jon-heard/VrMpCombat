using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  protected Character _character;

  protected virtual void Start()
  {
    _character = GetComponent<Character>();
  }
}
