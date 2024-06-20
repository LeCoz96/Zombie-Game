using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTest : Interactable
{
    [SerializeField] private InventoryItemData referenceItem;

    protected override void Interact()
    {
        InventorySystem.Instance.Add(referenceItem);
        Destroy(gameObject);
    }
}
