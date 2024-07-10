using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(_gameManager.OnStart);
    }
}
