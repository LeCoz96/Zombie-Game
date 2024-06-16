using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateText(string message)
    {
        _text.text = message;
    }
}
