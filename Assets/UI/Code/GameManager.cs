using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Interactions
{
    Shopkeeper,
    ItemForSale,
    ExitDoor
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _titleScreen;
    [SerializeField] private GameObject _shoppingInterface;
    [SerializeField] private GameObject _inventoryScreen;
    [SerializeField] private TypewriterFX _shopkeeperTextBubble;
    [SerializeField] private TextBubbleView _playerTextBubble;
    [SerializeField] private BlackBlurFX _blackBlurFX;
    private List<string> _messages = new List<string>() ;

    #region GAME_START

    public void OnStart()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        _blackBlurFX.ShowBlur();
        yield return new WaitForSeconds(5f);
        StartGame();
    }

    private void StartGame()
    {
        _titleScreen.SetActive(false);
    }

    #endregion GAME_START

    #region TRY_INTERACTION

    public void TryInteraction(Interactions interaction)
    {
        switch (interaction)
        {
            case Interactions.Shopkeeper:
                _shoppingInterface.gameObject.SetActive(true);
                break;

            case Interactions.ItemForSale:
                
                _messages.Add(StringConstants.ItemForSaleInteraction);
                _playerTextBubble.LoadMessages(_messages);
                break;

            case Interactions.ExitDoor:
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#endif
                Application.Quit();
                break;
        }
    }

    #endregion TRY_INTERACTION

    #region PUBLIC_METHODS

    public void CloseShop()
    {
        _shoppingInterface.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        if (_inventoryScreen.gameObject.activeInHierarchy == false)
            _inventoryScreen.SetActive(true);
        else
            _inventoryScreen.SetActive(false);
    }

    #endregion PUBLIC_METHODS
}