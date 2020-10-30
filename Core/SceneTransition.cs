using System;
using UnityEngine;

namespace D2D.Core
{
    /// <summary>
    /// Should be used in finish scene transitions
    /// Usage: Dotween animation should call CompleteTransition in animation`s Finished event
    /// Should exists as a single instance or
    /// </summary>
    public class SceneTransition : MonoBehaviour
    {
        public event Action Completed;

        // For using it with dotween on complete
        public void CompleteTransition()
        {
            Completed?.Invoke();
        }
    }
}