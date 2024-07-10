using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private InteractionMessageView _messageView;
    private Interactions _interaction;
    private bool _interactionPending = false;

    private void Update()
    {
        if (_interactionPending == false)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnLoadInteraction();
            _gameManager.TryInteraction(_interaction);
        }
    }

    public void LoadInteraction(Interactions interaction)
    {
        _interaction = interaction;
        _interactionPending = true;
        _messageView.gameObject.SetActive(true);
        switch (interaction)
        {
            case Interactions.Shopkeeper:
                _messageView.SetText(StringConstants._shopkeeperInteract);
                break;

            case Interactions.ItemForSale:
                _messageView.SetText(StringConstants._itemForSaleInteract);
                break;

            case Interactions.ExitDoor:
                _messageView.SetText(StringConstants._exitDoorInteract);
                break;
        }
    }

    public void UnLoadInteraction()
    {
        Debug.Log("Unloading interaction!");
        _interactionPending = false;
        _messageView.SetText("");
        _messageView.gameObject.SetActive(false);
    }
}