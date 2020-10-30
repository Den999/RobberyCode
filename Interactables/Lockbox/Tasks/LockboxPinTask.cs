using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using D2D;
using D2D.Utils;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockboxPinTask : LockboxTask
{
    [SerializeField] private string _answerPin;
    [SerializeField] private int _maxPinLen = 6;
    [SerializeField] private Button3d[] _numberButtons;
    [SerializeField] private Button3d _cleanButton;
    [SerializeField] private TextMeshPro _currentPinOutput;

    private string _currentPin = "";

    private string CurrentPin
    {
        get => _currentPin;
        set
        {
            _currentPin = value;
            _currentPinOutput.text = _currentPin;
        }
    }

    public override bool IsCompleted
    {
        get
        {
            if (CurrentPin != _answerPin)
            {
                CurrentPin = "";
                return false;
            }

            return true;
        }
    }

    private void OnEnable()
    {
        foreach (Button3d button in _numberButtons)
            button.Pressed += AddPinDigit;
        
        _cleanButton.Pressed += ResetCurrentPin;
    }
    
    private void OnDisable()
    {
        foreach (Button3d button in _numberButtons)
            button.Pressed -= AddPinDigit;

        _cleanButton.Pressed -= ResetCurrentPin;
    }

    private void ResetCurrentPin(int obj)
    {
        CurrentPin = "";
    }

    private void AddPinDigit(int buttonNumber)
    {
        CurrentPin += buttonNumber;

        if (CurrentPin.Length > _maxPinLen)
            CurrentPin = "";
    }
}

