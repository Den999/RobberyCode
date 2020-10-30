using System;
using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Utils;
using DG.Tweening;
using UnityEngine;

public class EnemyLightShaker : MonoBehaviour
{
    [SerializeField] private Vector3 _minRotation;
    [SerializeField] private Vector3 _maxRotation;
    [SerializeField] private Vector2 _delay;
    [SerializeField] private Vector2 _duration;

    [SerializeField] private float _worryFactorToPanic;
    [SerializeField] private float _panicSpeedUpFactor;

    private WorryHub _worryHub;

    private bool IsPanic => _worryHub.WorryFactor >= _worryFactorToPanic;

    private void Start()
    {
        _worryHub = FindObjectOfType<WorryHub>();
        FunctionTimer.Create(Move, DMath.Random(_delay));
    }

    private void Move()
    {
        var x = DMath.Random(_minRotation.x, _maxRotation.x);
        var y = DMath.Random(_minRotation.y, _maxRotation.y);
        var z = DMath.Random(_minRotation.z, _maxRotation.z);
        var desiredRotation = new Vector3(x, y, z);

        float duration = DMath.Random(_duration);
        if (IsPanic)
            duration /= _panicSpeedUpFactor;

        transform.DORotate(desiredRotation, duration).SetEase(Ease.InOutSine);

        float delay = DMath.Random(_delay);
        if (IsPanic)
            delay /= _panicSpeedUpFactor;
        
        FunctionTimer.Create(Move, delay);
    }
}
