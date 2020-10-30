using System;
using Cinemachine;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class FocusableInteractable : Interactable
    {
        [SerializeField] private CinemachineVirtualCamera _focusCamera;
        [SerializeField] private GameObject[] _focusContent;
        
        protected bool IsFocused { get; private set; }

        private void Awake()
        {
            SwitchContent(false);
        }

        protected override void OnAction()
        {
            var interactableHub = gameObject.FindOrCreate<FocusableHub>();
            interactableHub.Current = this;

            Focus();
        }

        private void Focus()
        {
            var hub = gameObject.FindOrCreate<CameraHub>();
            hub.SetTempCamera(_focusCamera);

            SwitchContent(true);

            IsFocused = true;
        }

        public void Unfocus()
        {
            var hub = gameObject.FindOrCreate<CameraHub>();
            hub.RemoveTempCamera(_focusCamera);
            
            SwitchContent(false);

            IsFocused = false;
        }
        
        private void SwitchContent(bool state)
        {
            foreach (GameObject content in _focusContent)
            {
                content.gameObject.SetActive(state);
            }
        }
    }
}