using System;
using D2D.UI;
using UnityEngine;
using UnityEngine.UI;

namespace D2D
{
    public class Item : Interactable
    {
        [SerializeField] private string itemName;
        [SerializeField] private int itemAmount;
        [SerializeField] private bool isInventoryMember;
        [SerializeField] private Sprite itemIcon;

        public event Action<Item> Picked;
        public event Action<Item> Threw; 
        
        public int ItemAmount => itemAmount;
        public Sprite ItemIcon => itemIcon;

        protected override void OnAction()
        {
            OnPick();

            if (isInventoryMember)
                Pick();
        }
        
        private void Pick()
        {
            Picked?.Invoke(this);

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }

        public void Throw()
        {
            Threw?.Invoke(this);
        }

        protected virtual void OnPick()
        {
            
        }
    }
}