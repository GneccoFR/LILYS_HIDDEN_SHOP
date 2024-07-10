using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterFX : MonoBehaviour
{
    [SerializeField] private TextBubbleView _textBubbleView;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    [SerializeField] private float _timeBetweenCharacters;
    [SerializeField] private float _timeBetweenWords;
    [SerializeField] private bool _showOnStart;
    private List<string> _strings = new List<string>();
    private int i = 0;
    private bool _showing = false;

    private void Start()
    {
        _button.onClick.AddListener(EndCheck);
        if(_showOnStart)
            EndCheck();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _showing == false)
            EndCheck();
    }

    public void LoadStrings(List<string> messages)
    {
        i = 0; 
        _strings = messages;
        EndCheck();
    }

    public void EndCheck()
    {
        if (_strings.Count <= 0)
        {
            Debug.LogWarning("No strings loaded!!");
            return;
        }
        if (i <= _strings.Count - 1)
        {
            _text.text = _strings[i].ToString();
            StartCoroutine(ShowText());
        }
        else 
            _textBubbleView.HideBubble();
    }

    private IEnumerator ShowText()
    {
        _text.ForceMeshUpdate();
        int visibleCharacters = _text.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            _showing = true;
            int visibleCount = counter % (visibleCharacters + 1);
            _text.maxVisibleCharacters = visibleCount;

            counter += 1;

            if (visibleCount >= visibleCharacters)
            {
                i += 1;
                break;
            }

            yield return new WaitForSeconds(_timeBetweenCharacters);
        }
        _showing = false;
    }
}