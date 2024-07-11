using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _button;
    [SerializeField] private RectTransform _helperRect;


    private void OnDisable()
    {
        _helperRect.gameObject.SetActive(true);
    }

    private void Start()
    {
        _button.onClick.AddListener(_gameManager.OnStart);
    }
}
