using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float _speed;

    void Update()
    {
        float speed = _material.mainTextureOffset.y + _speed * Time.deltaTime;
        _material.mainTextureOffset = new Vector2(0, speed);
    }
}
