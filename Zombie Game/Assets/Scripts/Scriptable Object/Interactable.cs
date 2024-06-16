using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : ScriptableObject
{
    public string prompt;

    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact() { }

}
