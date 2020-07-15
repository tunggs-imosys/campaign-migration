using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsideValidator<T> : ExtensionBehaviour<T> where T : Component
{
  [TextArea] public string FailureMessage = string.Empty;

  public virtual bool Validate() => false;
}
