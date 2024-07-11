using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private TextMeshProUGUI _playerMoneyCount;
    [SerializeField] private TextMeshProUGUI _shopkeeperMoneyCount;
    [SerializeField] private ShopListItemView[] _shopItemButtons;
    [SerializeField] private ShopItemView[] _shopItems;
    private Dictionary<ShopListItemView, ShopItemView> _shopItemList;
    public int ShopkeeperMoney = 0;


    private void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
            _gameManager.CloseShop();
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _shopItemList = new Dictionary<ShopListItemView, ShopItemView>()
        {
            {_shopItemButtons[0], _shopItems[0]},
            {_shopItemButtons[1], _shopItems[1]},
            {_shopItemButtons[2], _shopItems[2]},
            {_shopItemButtons[3], _shopItems[3]},
            {_shopItemButtons[4], _shopItems[4]},
            {_shopItemButtons[5], _shopItems[5]},
        };

        foreach (var item in _shopItemList) 
        {
            item.Key.SetButtonListener(() => SellItem(item.Key, item.Value));
            item.Key.SetCost((Int32.Parse(item.Key.ItemID) * 1000).ToString());
            LoadDescriptionAndSetBuyable(item.Key);
            item.Key.BuyableByPlayer = true;
        }

        _playerMoneyCount.text = _inventoryController.PlayerMoney.ToString();
        _shopkeeperMoneyCount.text = ShopkeeperMoney.ToString();
    }

    private void LoadDescriptionAndSetBuyable(ShopListItemView item)
    {
        switch (item.ItemID)
        {
            case "001":
                item.SetItemBuyable(StringConstants.ItemDescription_001);
                break;
            case "002":
                item.SetItemBuyable(StringConstants.ItemDescription_002);
                break;
            case "003":
                item.SetItemBuyable(StringConstants.ItemDescription_003);
                break;
            case "004":
                item.SetItemBuyable(StringConstants.ItemDescription_004);
                break;
            case "005":
                item.SetItemBuyable(StringConstants.ItemDescription_005);
                break;
            case "006":
                item.SetItemBuyable(StringConstants.ItemDescription_006);
                break;
        }
    }

    private void SellItem(ShopListItemView shopButton, ShopItemView item)
    {
        if (shopButton.BuyableByPlayer)
        {
            if(_inventoryController.PlayerMoney >= shopButton.GetCost)
            {
                item.ItemSold();
                _inventoryController.AcquireItem(shopButton.ItemID);
                shopButton.SetItemSellable();
                _inventoryController.PlayerMoney -= shopButton.GetCost;
                ShopkeeperMoney += shopButton.GetCost;
                _shopkeeperMoneyCount.text = ShopkeeperMoney.ToString();
                _playerMoneyCount.text = _inventoryController.PlayerMoney.ToString();
            }
        }
        else
        {
            if(ShopkeeperMoney >= shopButton.GetCost)
            {
                item.ItemBuyed();
                _inventoryController.ReleaseItem(shopButton.ItemID);
                LoadDescriptionAndSetBuyable(shopButton);
                _inventoryController.PlayerMoney += shopButton.GetCost;
                ShopkeeperMoney -= shopButton.GetCost;
                _shopkeeperMoneyCount.text = ShopkeeperMoney.ToString();
                _playerMoneyCount.text = _inventoryController.PlayerMoney.ToString();
            }
        }
    }
}
