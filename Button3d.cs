using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Button3d : MonoBehaviour
{
    [SerializeField] private int _number;
    [SerializeField] private DOTweenAnimation _pressAnim;
    [SerializeField] private TextMeshPro _numberLabel;

    public event Action<int> Pressed;

    private void OnDrawGizmos()
    {
        if (_numberLabel != null)
            _numberLabel.text = _number.ToString();
    }

    private void Awake()
    {
        if (_numberLabel != null)
            _numberLabel.text = _number.ToString();
    }

    private void OnMouseDown()
    {
        _pressAnim.DORestart();
        Pressed?.Invoke(_number);
    }
}
