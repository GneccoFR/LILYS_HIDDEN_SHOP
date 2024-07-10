using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionMessageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void SetText(string value)
    {
        _text.text = value;
    }
}
