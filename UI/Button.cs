using System;
using System.Linq;
using DG.Tweening;
using UltEvents;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace D2D.UI
{
    /// <summary>
    /// Lighter button class with more events.
    /// </summary>
    public class Button : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private UltEvent clicked;

        public event Action Clicked;

        private bool _isInteractable = true;

        public void InvokeClick()
        {
            if (!_isInteractable)
                return;
            
            clicked?.Invoke();
            Clicked?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InvokeClick();
        }
    }
}