using System;
using System.Collections;
using System.Collections.Generic;
using D2D.Core;
using D2D.Utils;
using Robbery;
using TMPro;
using UnityEngine;

public class Escape : Interactable
{
    public event Action PlayerEscaped;

    private RobberyList _robberyList;

    private void OnEnable()
    {
        _robberyList = FindObjectOfType<RobberyList>();
        _robberyList.Changed += UpdateInteractivity;
    }

    private void OnDisable()
    {
        _robberyList.Changed -= UpdateInteractivity;
    }
    
    private void UpdateInteractivity()
    {
        isInteractable = _robberyList.IsCompleted;
    }

    protected override void OnAction()
    {
        PlayerEscaped?.Invoke();
    }
}
