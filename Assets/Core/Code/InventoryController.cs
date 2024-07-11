using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private List<InventoryItemView> _inventoryItemView;
    [SerializeField] private TextMeshProUGUI _inventoryMoneyCount;
    [SerializeField] private Player _player;
    public int PlayerMoney = 21000;
    private List<string> _itemsAcquired = new List<string>();

    private void Start()
    {
        foreach (var item in _inventoryItemView)
        {
            item.SetButtonListener(()=> _player.SetHat(item._icon.sprite, item.ItemID));
            switch (item.ItemID)
            {
                case "001":
                    item.SetDescription(StringConstants.ItemDescription_001);
                    break;
                case "002":
                    item.SetDescription(StringConstants.ItemDescription_002);
                    break;
                case "003":
                    item.SetDescription(StringConstants.ItemDescription_003);
                    break;
                case "004":
                    item.SetDescription(StringConstants.ItemDescription_004);
                    break;
                case "005":
                    item.SetDescription(StringConstants.ItemDescription_005);
                    break;
                case "006":
                    item.SetDescription(StringConstants.ItemDescription_006);
                    break;
            }
        }
        UpdateItemList();
    }

    public void AcquireItem(string itemID)
    {
        _itemsAcquired.Add(itemID);
        UpdateItemList();
    }

    public void ReleaseItem(string itemID) 
    {
        if (itemID == _player._wornItem)
            _player.SetDefaultHat();
        _itemsAcquired.Remove(itemID);
        UpdateItemList();
    }

    public void UpdateItemList()
    {
        _inventoryMoneyCount.text = PlayerMoney.ToString();
        foreach(var item in _inventoryItemView)
        {
            if(!_itemsAcquired.Contains(item.ItemID))
                item.gameObject.SetActive(false);
            else 
                item.gameObject.SetActive(true);
        }
    }
}
