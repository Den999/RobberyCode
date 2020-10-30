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
    [SerializeField] private TextMeshPro _label;
    
    public event Action PlayerEscaped;

    private RobberyList _robberyList;

    private void Awake()
    {
        _robberyList = FindObjectOfType<RobberyList>();
    }
    private void Update()
    {
        UpdateInteractivity();
    }

    private void UpdateInteractivity()
    {
        // isInteractable = true;
        isInteractable = _robberyList.IsCompleted;
        _label.gameObject.SetActive(_robberyList.IsCompleted);
    }

    protected override void OnAction()
    {
        var sceneLoader = gameObject.FindOrCreate<SceneLoader>();
        sceneLoader.LoadMainMenu();
        // PlayerEscaped?.Invoke();
    }
}
