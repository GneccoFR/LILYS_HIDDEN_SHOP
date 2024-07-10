using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private InteractionController _interactionController;
    [SerializeField] private int _money = 21000;
    [SerializeField] private float _movementSpeed = 3.666f;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    private float xInput, yInput;

    [Header("Player objects references")]
    [SerializeField] private SpriteRenderer _hat;
    [SerializeField] private SpriteRenderer _mask;
    [SerializeField] private SpriteRenderer _outfit;

    [Header("Avatar objects references")]
    [SerializeField] private Image _avatarHat;
    [SerializeField] private Image _avatarMask;
    [SerializeField] private Image _avatarOutfit;

    private void Update()
    {
        PlayerMovementInput();
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

    internal void OnCollisionLeave()
    {
        _interactionController.UnLoadInteraction();
    }
}