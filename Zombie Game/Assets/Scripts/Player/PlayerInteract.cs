using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] private float _interactionDistance;

    [SerializeField] private LayerMask _interactLayer;

    void Update()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _interactionDistance, _interactLayer))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {

            }
        }

    }
}
