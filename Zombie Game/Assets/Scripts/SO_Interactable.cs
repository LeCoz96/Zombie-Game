using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Interactable : ScriptableObject
{
    public string Message;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact() { }
}
