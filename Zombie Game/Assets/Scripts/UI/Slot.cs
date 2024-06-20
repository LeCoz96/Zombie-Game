using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _stackObject;
    [SerializeField] private TextMeshProUGUI _stackQuantity;

    public void Set(InventoryItem item)
    {
        _icon.sprite = item.Data.Icon;
        if (item.StackSize <= 0)
        {
            _stackObject.SetActive(false);
            return;
        }

        _stackQuantity.text = item.StackSize.ToString();
    }

}
