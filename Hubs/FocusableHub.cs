using System;
using D2D.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace D2D
{
    public class FocusableHub : SwitchableHub<FocusableInteractable>
    {
        [SerializeField] private KeyCode _unfocusKey;
        [SerializeField] private Volume _defaultPP;
        [SerializeField] private Volume _focusedPP;
        
        [SerializeField] CanvasGroup _mainCanvasGroup;
        [SerializeField] CanvasGroup _focusesCanvasGroup;
        private MeshRenderer _playerRenderer;

        private void Start()
        {
            _playerRenderer = FindObjectOfType<Player>().GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_unfocusKey))
                UnfocusCurrentIfExists();
        }

        private void UnfocusCurrentIfExists()
        {
            Debug.Log(Current);
            
            if (Current != null)
                SwitchMember(Current, false);
        }

        protected override void SwitchMember(FocusableInteractable member, bool state)
        {
            if (state)
            {
                FocusGameView(true);
            }
            else
            {
                FocusGameView(false);
                
                member.Unfocus();
            }
        }

        private void FocusGameView(bool state)
        {
            var profileHub = gameObject.FindOrCreate<PostProcessingProfileHub>();
            profileHub.Current = state ? _focusedPP : _defaultPP;

            FunctionTimer.Create(() => SwitchCanvases(state), .5f);
            _playerRenderer.gameObject.SetActive(!state);
        }

        private void SwitchCanvases(bool state)
        {
            _mainCanvasGroup.alpha = state ? 0 : 1;
            _focusesCanvasGroup.alpha = state ? 1 : 0;
        }
    }
}