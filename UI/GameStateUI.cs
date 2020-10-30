using System;
using D2D.Core;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class GameStateUI : GameStateMachineHasher
    {
        [SerializeField] private GameObject _winWindowPrefab;
        [SerializeField] private GameObject _loseWindowPrefab;

        private void OnEnable()
        {
            var windowHub = gameObject.FindOrCreate<WindowHub>();

            StateMachine.AdjustActionToState<WinState>(gameObject, 
                () => windowHub.CreateWindow(_winWindowPrefab));
            
            StateMachine.AdjustActionToState<LoseState>(gameObject, 
                () => windowHub.CreateWindow(_loseWindowPrefab));
        }
    }
}