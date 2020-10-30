using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Core;
using D2D.Utils;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MissionTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeLabel;
    [SerializeField] private DOTweenAnimation _clockShakeAnim;

    public event Action Expired;

    private float TimeLeft
    {
        get => _timeLeft;
        set
        {
            _timeLeft = value;
            Redraw();
        }
    }

    private float _timeLeft;
    private bool _timerIsActive;
    public bool IsExpired { get; private set; }

    private WindowHub _windowHub;

    private void Start()
    {
        _windowHub = gameObject.FindOrCreate<WindowHub>();
    }

    private void Update()
    {
        if (IsExpired)
            return;

        if (_timerIsActive && _windowHub.OpenedWindowNumber == 0)
            CountdownTick();
        
        if (_timeLeft <= 0)
            Expire();
    }

    public void StartTimer(float time)
    {
        TimeLeft = time;
        _timerIsActive = true;
    }

    public void StopTimer() => _timerIsActive = false;

    private void CountdownTick()
    {
        TimeLeft -= Time.deltaTime;
    }

    private void Redraw()
    {
        int secs =  Mathf.FloorToInt(TimeLeft % 60);
        int mins = Mathf.FloorToInt(TimeLeft / 60);
        
        string secsText = secs + "";
        if (secs < 10)
            secsText = "0" + secsText;

        string minsText = mins + "";
        if (mins < 10)
            minsText = "0" + minsText;

        _timeLabel.text = $"{minsText}:{secsText}";
    }

    private void Expire()
    {
        IsExpired = true;
        StopTimer();
        TimeLeft = 0;

        _clockShakeAnim.DOPlay();
        
        Expired?.Invoke();
    }
}
