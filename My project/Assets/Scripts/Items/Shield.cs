using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shield : Item
{
    [SerializeField] private int _hits;
    
    protected override void OnClick()
    {
        _hits--;

        if (_hits <= 0)
        {
            base.OnClick();
        }
    }
}
