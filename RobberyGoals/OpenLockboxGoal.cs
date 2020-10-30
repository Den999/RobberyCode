using System;
using UnityEngine;

namespace D2D
{
    public class OpenLockboxGoal : RobberyGoal
    {
        private LockBox _lockBox;

        private void OnEnable()
        {
            _lockBox = GetComponent<LockBox>();
            _lockBox.Opened += OnComplete;
        }

        private void OnDisable()
        {
            _lockBox.Opened -= OnComplete;
        }
    }
}