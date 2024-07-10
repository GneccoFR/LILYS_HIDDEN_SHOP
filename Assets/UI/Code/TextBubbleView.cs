using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleView : MonoBehaviour
{
    [SerializeField] private TypewriterFX _typewriter;
    [SerializeField] private RectTransform _bubbleRect;

    public void LoadMessages(List<string> messages)
    {
        ShowBubble();
        _typewriter.LoadStrings(messages);
    }

    public void HideBubble()
    {
        _bubbleRect.gameObject.SetActive(false);
    }

    public void ShowBubble() 
    {
        _bubbleRect.gameObject.SetActive(true);
    }
}
