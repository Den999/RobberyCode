using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace D2D
{
    public class PickItemGoal : RobberyGoal
    {
        private Item _item;

        private void OnEnable()
        {
            _item = GetComponent<Item>();
            _item.Picked += CompleteGoal;
        }

        private void OnDisable()
        {
            _item.Picked -= CompleteGoal;
        }

        private void CompleteGoal(Item item) => OnComplete();
    }
}