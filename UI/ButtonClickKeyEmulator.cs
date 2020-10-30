using System;
using D2D.UI;
using UnityEngine;

namespace D2D
{
    [RequireComponent(typeof(Button))]
    public class ButtonClickKeyEmulator : MonoBehaviour
    {
        [SerializeField] private KeyCode _keycode;

        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_keycode))
                _button.InvokeClick();
        }
    }
}