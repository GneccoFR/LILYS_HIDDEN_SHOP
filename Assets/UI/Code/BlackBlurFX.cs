using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBlurFX : MonoBehaviour
{
    [SerializeField] private CanvasGroup _image;
    [SerializeField] private float _fXTime;
    private bool _enabled = false;
    private bool _increasing = false;
    private float f = 0;


    public void ShowBlur()
    {
        _enabled = true;
        _increasing = true;
    }

    void Update()
    {
        if (_enabled) 
        {
            if (_increasing)
            {
                f = f + Time.deltaTime/5;
                _image.alpha = Math.Clamp(f, 0, 1);
                if (f >= _fXTime)
                    _increasing = false;
            }
            else
            {
                f = f - Time.deltaTime/5;
                _image.alpha = Math.Clamp(f, 0, 1);
                if (f <= 0)
                    _enabled = false;
            }
        }
    }
}
