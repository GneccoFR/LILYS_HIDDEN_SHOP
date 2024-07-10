using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ShopListItemView[] _shopItemButtons;
    [SerializeField] private ShopItemView[] _shopItems;
    private Dictionary<ShopListItemView, ShopItemView> _shopItemList;



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
        }
    }



    private void SellItem(ShopListItemView shopButton, ShopItemView item)
    {
        item.ItemSold();
        shopButton.SetButtonInteractable(false);
    }
}
