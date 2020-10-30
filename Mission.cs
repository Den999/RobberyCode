﻿using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Core;
using D2D.Utils;
using Robbery;
using UnityEngine;

public class Mission : GameStateMachineHasher
{
    [SerializeField] private int timeLimitInSeconds;

    [Space(5)]
    
    [SerializeField] private Material daySkybox;
    [SerializeField] private Light dayLight;

    private MissionTimer _timer;
    private Escape _escape;
    private WorryHub _worryHub;

    private void OnEnable()
    {
        _timer = FindObjectOfType<MissionTimer>();
        if (_timer != null)
        {
            _timer.StartTimer(timeLimitInSeconds);
            _timer.Expired += MissionTimeIsUp;
        }
            
        _escape = FindObjectOfType<Escape>();
        _escape.PlayerEscaped += EscapeFromMission;

        _worryHub = gameObject.FindOrCreate<WorryHub>();
        _worryHub.WorryOverhead += PlayerCaught;
    }

    private void OnDisable()
    {
        if (_timer != null)
            _timer.Expired -= MissionTimeIsUp;

        _escape.PlayerEscaped -= EscapeFromMission;

        _worryHub.WorryOverhead -= PlayerCaught;
    }

    private void PlayerCaught()
    {
        LoseMission();
        
        _timer.StopTimer();
    }

    private void MissionTimeIsUp()
    {
        SetDay();
        LoseMission();
    }
    
    private void EscapeFromMission()
    {
        if (_timer.IsExpired)
            return;

        _timer.StopTimer();
        WinMission();
    }
    
    private void SetDay()
    {
        RenderSettings.skybox = daySkybox;
        DynamicGI.UpdateEnvironment();
        
        dayLight.gameObject.SetActive(true);
    }

    private void LoseMission()
    {
        StateMachine.PushState(new LoseState());
    }

    private void WinMission()
    {
        StateMachine.PushState(new WinState());
        Debug.Log("...");
    }
}
