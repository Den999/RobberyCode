using System;
using D2D.Utils;
using TMPro;
using UnityEngine;

namespace D2D
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label1;

        private WindowHub _windowHub;

        private void Start()
        {
            _windowHub = gameObject.FindOrCreate<WindowHub>();
            _label1 = GetComponent<TextMeshProUGUI>();
        }

        public void Show(string interactableName, string interactableDescription)
        {
            if (_windowHub.OpenedWindowNumber > 0)
            {
                Hide();
                return;
            }

            if (interactableName.Trim() != "")
            {
                _label1.text = $"{interactableName}: {interactableDescription}";
            }
            else
            {
                _label1.text = interactableDescription;
            }
        }

        public void Hide()
        {
            _label1.text = "";
        }
    }
}