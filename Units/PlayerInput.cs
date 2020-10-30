using System;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    [Serializable]
    public class InputKey
    {
        public KeyCode[] keyCodes;
        [HideInInspector] public bool IsPressed;
    }
    
    public class PlayerInput : MonoBehaviour
    {
        public InputKey forwardKey;
        public InputKey backwardKey;
        public InputKey leftKey;
        public InputKey rightKey;

        [Space(5)]
        
        public InputKey jumpKey;

        [SerializeField] private int _crawlMouseButtonIndex; 

        public bool CrawlButtonPressed { get; private set; }

        public Vector2 Movement { get; private set; }

        [HideInInspector] public bool inputEnabled = true;
        
        private WindowHub _windowHub;

        private void Awake()
        {
            _windowHub = gameObject.FindOrCreate<WindowHub>();
        }

        private void Update()
        {
            inputEnabled = _windowHub.OpenedWindowNumber == 0;
            
            CheckMouse();

            CrawlButtonPressed = Input.GetMouseButton(_crawlMouseButtonIndex);
            
            CheckKey(forwardKey);
            CheckKey(backwardKey);
            CheckKey(jumpKey);
        }

        private void CheckMouse()
        {
            if (!inputEnabled)
            {
                Movement = Vector2.zero;
                return;
            }
            
            Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        private void CheckKey(InputKey key)
        {
            if (!inputEnabled)
            {
                key.IsPressed = false;
                return;
            }

            key.IsPressed = false;
            foreach (KeyCode keyCode in key.keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    key.IsPressed = true;
                    break;
                }
            }
        }
    }
}