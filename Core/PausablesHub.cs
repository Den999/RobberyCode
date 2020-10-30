using System;
using System.Collections.Generic;
using D2D.Utils;
using UnityEngine;

namespace D2D.Core
{
    /// <summary>
    /// Activates and deactivates pausables according to
    /// current game state IsGameActiveDuringState option
    /// </summary>
    public class PausablesHub : MonoBehaviour, ILazyCreating
    {
        /// <summary>
        /// All existed pausable objects in game 
        /// </summary>
        private static List<PausablesMember> pausables = new List<PausablesMember>();

        private GameStateMachine _gameStateMachine;

        private void OnEnable()
        {
            _gameStateMachine = gameObject.FindOrCreate<GameStateMachine>();
            
            // Adjust switching pausable activity to any state
            _gameStateMachine.AdjustActionToState<GameState>(gameObject, SwitchPausablesActivity);
        }
        
        private void SwitchPausablesActivity()
        {
            for (int i = 0; i < pausables.Count; i++)
            {
                // Remove null or already destroyed pausables
                if (pausables[i] == null || pausables[i].gameObject == null)
                {
                    pausables.RemoveAt(i);
                    continue;
                }
                
                // If all is ok, update pausable activity according to current game state
                pausables[i].gameObject.SetActive(_gameStateMachine.Last.IsGameActiveDuringState);
            }
        }

        /// <summary>
        /// Register pausable. So now, new object will be paused or not according to game state
        /// </summary>
        public void AddPausable(PausablesMember newPausable)
        {
            pausables.Add(newPausable);

            if (_gameStateMachine.IsEmpty || !_gameStateMachine.Last.IsGameActiveDuringState)
                newPausable.gameObject.SetActive(false);
        }
    }
}
