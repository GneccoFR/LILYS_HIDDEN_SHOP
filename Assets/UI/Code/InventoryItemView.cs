using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _description;
    public Image _icon;
    public string ItemID;

    public void SetButtonListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }

    public void SetButtonInteractable(bool value)
    {
        _button.interactable = value;
    }

    public void SetDescription(string value)
    {
        _description.text = value;
    }


}
