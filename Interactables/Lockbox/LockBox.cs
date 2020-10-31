using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Utils;
using DG.Tweening;
using UnityEngine;

public class LockBox : FocusableInteractable
{
    [SerializeField] private Button3d _openButton;
    [SerializeField] private DOTweenAnimation _openAnim;
    [SerializeField] private GameObject _openContent;

    public event Action Opened;

    private LockboxTask _task;
    
    private void OnEnable()
    {
        _task = GetComponent<LockboxTask>();
        _openButton.Pressed += TryOpen;
    }

    private void OnDisable()
    {
        _openButton.Pressed -= TryOpen;
    }

    private void TryOpen(int obj)
    {
        if (_task.IsCompleted)
        {
            _openAnim.DOPlay();
            Opened?.Invoke();
            _openContent.gameObject.SetActive(true);
        }
    }
}
