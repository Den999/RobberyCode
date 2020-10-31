using System;
using System.Collections.Generic;
using D2D;
using D2D.Core;
using D2D.Utils;
using UnityEngine;
using Robbery;

namespace Robbery
{
    public class RobberyList : MonoBehaviour
    {
        [SerializeField] private Transform _linesContainer;
        
        private RobberyGoal[] _goals;
        private List<RobberyListLine> _lines = new List<RobberyListLine>();

        public event Action Changed;

        public bool IsCompleted
        {
            get
            {
                foreach (RobberyGoal goal in _goals)
                {
                    if (!goal.IsCompleted)
                        return false;
                }

                return true;
            }
        }

        private void OnEnable()
        {
            _goals = FindObjectsOfType<RobberyGoal>();
            foreach (RobberyGoal goal in _goals)
                goal.Completed += UpdateList;

            CreateLines();
        }

        private void CreateLines()
        {
            // Remove prevoius lines
            foreach (var lines in GetComponentsInChildren<RobberyListLine>())
                Destroy(lines);

            for (int i = 0; i < _goals.Length; i++)
            {
                var newLine = Instantiate(GameData.Instance.robberyListLinePrefab, _linesContainer).
                    GetComponent<RobberyListLine>();
                _lines.Add(newLine);
            }
            
            UpdateList();
        }

        private void UpdateList()
        {
            Changed?.Invoke();

            // Redraw
            for (int i = 0; i < _goals.Length; i++)
            {
                _lines[i].Render(_goals[i]);
            }
        }
    }
}