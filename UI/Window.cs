using System;
using UnityEngine;

namespace D2D
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private bool _isPriority;
        [SerializeField] private bool _forceMoveToFront;

        public bool IsPriority => _isPriority;

        private void Start()
        {
            var canvas = FindObjectOfType<Canvas>();
            transform.parent = canvas.transform;
            transform.localPosition = Vector3.zero;

            if(_forceMoveToFront)
                transform.SetSiblingIndex(0);
        }

        public void Close()
        {
            Destroy(gameObject);
        }
    }
}