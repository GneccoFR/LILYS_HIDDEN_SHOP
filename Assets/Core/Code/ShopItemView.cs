using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void ItemSold()
    {
        _spriteRenderer.gameObject.SetActive(false);
    }

    public void ItemBuyed()
    {
        _spriteRenderer.gameObject.SetActive(true);
    }

    public void loadItem(Sprite sprite)
    {
        _spriteRenderer.gameObject.SetActive(true);
        _spriteRenderer.sprite = sprite;
    }
}
