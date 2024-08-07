using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopListItemView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _cost;
    public string ItemID;
    public bool BuyableByPlayer;

    public int GetCost => Int32.Parse(_cost.text);

    public void SetButtonListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }

    public void SetButtonInteractable(bool value)
    {
        _button.interactable = value;
    }

    public void SetItemBuyable(string value)
    {
        BuyableByPlayer = true;
        _description.text = value;
    }

    public void SetItemSellable()
    {
        BuyableByPlayer = false;
        _description.text = StringConstants.SellableItem;
    }

    public void SetDescription(string value)
    {
        _description.text = value;
    }

    public void SetCost(string value)
    {
        _cost.text = value;
    }
}
