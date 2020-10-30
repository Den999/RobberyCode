using System;
using DG.Tweening;
using UnityEngine;

namespace D2D
{
    public class Switch : Interactable
    {
        [SerializeField] private Transform _handle;

        [SerializeField] private Vector3 _toRotate;

        [SerializeField] private Rigidbody _wall;
        
        public bool State { get; private set; }
        public event Action SwitchStateChanged;
        
        protected override void OnAction()
        {
            InvertState();
        }

        private void InvertState()
        {
            State = !State;
            SwitchStateChanged?.Invoke();
            
            Debug.Log(State);

            var to = State ? _toRotate : _toRotate * -1;
            _handle.DORotate(to, .6f);

            if (State && _wall != null && _wall.isKinematic)
            {
                _wall.isKinematic = false;
            }
        }
    }
}