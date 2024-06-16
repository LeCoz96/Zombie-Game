using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [SerializeField] private GameObject cube;

    private bool _isMoving = false;

    protected override void Interact()
    {
        _isMoving = !_isMoving;
        cube.GetComponent<Animator>().SetBool("IsMoving", true);
    }
}

