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
    [SerializeField] private TypewriterFX _shopkeeperTextBubble;
    [SerializeField] private BlackBlurFX _blackBlurFX;
    [SerializeField] private GameObject _shoppingInterface;

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
        Debug.Log("Trying to interact!");
        switch (interaction)
        {
            case Interactions.Shopkeeper:
                _shoppingInterface.gameObject.SetActive(true);
                break;

            case Interactions.ItemForSale:
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

    #endregion PUBLIC_METHODS
}