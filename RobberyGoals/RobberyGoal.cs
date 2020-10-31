using System;
using UnityEngine;

namespace D2D
{
    public class RobberyGoal : MonoBehaviour
    {
        [SerializeField] private string _goalName;

        public string GoalName => _goalName;

        public bool IsCompleted { get; private set; }

        public event Action Completed;
        
        protected void OnComplete()
        {
            IsCompleted = true;
            Completed?.Invoke();
        }
    }
}