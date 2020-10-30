using System;
using System.Collections.Generic;
using System.Linq;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class WindowHub : MonoBehaviour, ILazyCreating
    {
        [SerializeField] private Transform _mainCanvas;
        
        private List<Window> _openedWindows = new List<Window>();

        public int OpenedWindowNumber => _openedWindows.Count;

        private void Start()
        {
            FunctionPeriodic.Create(UpdateWindowsList, 1 / 20f);
        }

        private void UpdateWindowsList()
        {
            _openedWindows = FindObjectsOfType<Window>().ToList();
        }

        public Window CreateWindow(GameObject windowPrefab)
        {
            var newWindow = Instantiate(windowPrefab, _mainCanvas).GetComponent<Window>();
            CloseWindows(newWindow.IsPriority);

            return newWindow;
        }

        private void CloseWindows(bool closePriorityToo)
        {
            foreach (Window openedWindow in _openedWindows)
            {
                if (openedWindow.IsPriority)
                {
                    if (closePriorityToo)
                        openedWindow.Close();
                }
                else
                {
                    openedWindow.Close();
                }
            }
        }
    }
}