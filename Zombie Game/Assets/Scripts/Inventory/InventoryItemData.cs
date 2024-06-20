using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string Id;
    public string DisplayName;
    public string Description;
    public Sprite Icon;
    public GameObject Prefab;
    //public GameObject PrefabUI;
    //public ItemType Type;

    // https://www.youtube.com/watch?v=SGz3sbZkfkg&t=509s
}

