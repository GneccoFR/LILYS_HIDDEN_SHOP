using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private InteractionController _interactionController;
    [SerializeField] private float _movementSpeed = 3.666f;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    private float xInput, yInput;
    public string _wornItem = "";

    [SerializeField] private Sprite _defaultHat;

    [Header("Player objects references")]
    [SerializeField] private SpriteRenderer _hat;
    [SerializeField] private SpriteRenderer _mask;
    [SerializeField] private SpriteRenderer _outfit;

    [Header("Shop Avatar objects references")]
    [SerializeField] private Image _avatarHat;
    [SerializeField] private Image _avatarMask;
    [SerializeField] private Image _avatarOutfit;
    
    [Header("Inventory Avatar objects references")]
    [SerializeField] private Image _inventoryAvatarHat;
    [SerializeField] private Image _inventoryAvatarMask;
    [SerializeField] private Image _inventoryAvatarOutfit;

    private void Update()
    {
        PlayerMovementInput();
        if (Input.GetKeyDown(KeyCode.I))
            _gameManager.OpenInventory();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * _movementSpeed * Time.deltaTime, yInput * _movementSpeed * Time.deltaTime);
        _rigidBody2D.MovePosition(_rigidBody2D.position + move);
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if (xInput != 0 && yInput != 0)
        {
            xInput *= .71f;
            yInput *= .71f;
        }
    }

    public void OnCollision(string tag)
    {
        switch (tag)
        {
            case "Shopkeeper":
                _interactionController.LoadInteraction(Interactions.Shopkeeper);
                break;

            case "ItemForSale":
                _interactionController.LoadInteraction(Interactions.ItemForSale);
                break;

            case "ExitDoor":
                _interactionController.LoadInteraction(Interactions.ExitDoor);
                break;
        }
    }

    public void SetHat(Sprite sprite, string Id)
    {
        _wornItem = Id;
        _hat.sprite = sprite;
        _avatarHat.sprite = sprite;
        _inventoryAvatarHat.sprite = sprite;
    }

    public void SetDefaultHat()
    {
        _wornItem = "";
        _hat.sprite = _defaultHat;
        _avatarHat.sprite = _defaultHat;
        _inventoryAvatarHat.sprite = _defaultHat;
    }

    public void SetFace()
    {

    }

    public void SetOutfit()
    {

    }

    public void OnCollisionLeave()
    {
        _interactionController.UnLoadInteraction();
    }
}