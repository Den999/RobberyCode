using System;
using System.Collections.Generic;
using Robbery;
using UnityEngine;
using UnityEngine.UI;

namespace D2D
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _cellContainer;
        
        private List<Item> _itemsInInventory = new List<Item>();
        private List<InventoryCell> _inventoryCells = new List<InventoryCell>();

        private CanvasGroup _canvasGroup;
        
        public bool Contains(Item item) => _itemsInInventory.Contains(item);

        private void OnEnable()
        {
            var allItemsInGame = FindObjectsOfType<Item>();
            foreach (Item item in allItemsInGame)
            {
                item.Picked += AddItem;
                item.Threw += RemoveItem;
            }
            
            _canvasGroup = GetComponent<CanvasGroup>();
            Redraw();
        }

        private void OnDisable()
        {
            var allItemsInGame = FindObjectsOfType<Item>();
            foreach (Item item in allItemsInGame)
            {
                item.Picked -= AddItem;
                item.Threw -= RemoveItem;
            }
        }

        private void AddItem(Item item)
        {
            _itemsInInventory.Add(item);
            Redraw();
        }

        private void RemoveItem(Item removingItem)
        {
            _itemsInInventory.Remove(removingItem);
            Redraw();
        }

        private void Redraw()
        {
            _canvasGroup.alpha = _itemsInInventory.Count == 0 ? 0 : 1;
            
            for (int i = 0; i < _itemsInInventory.Count; i++)
            {
                if (_inventoryCells.Count <= i)
                    CreateCell();
                
                _inventoryCells[i].Render(_itemsInInventory[i]);
            }
        }

        private void CreateCell()
        {
            var newCell = Instantiate(GameData.Instance.inventoryCellPrefab, _cellContainer).GetComponent<InventoryCell>();
            _inventoryCells.Add(newCell);
        }
    }
}