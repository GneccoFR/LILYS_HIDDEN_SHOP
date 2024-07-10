using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _player.OnCollision(collision.gameObject.tag);
    }
}
