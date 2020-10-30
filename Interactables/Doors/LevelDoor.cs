using System.Collections;
using System.Collections.Generic;
using D2D;
using D2D.Core;
using D2D.Utils;
using UnityEngine;

public class LevelDoor : Interactable
{
    [SerializeField] private GameObject _levelDescription;

    protected override void OnAction()
    {
        var windowHub = gameObject.FindOrCreate<WindowHub>();
        windowHub.CreateWindow(_levelDescription);
    }
}
