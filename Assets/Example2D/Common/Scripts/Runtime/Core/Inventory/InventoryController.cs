using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example2D.Common.Runtime.Core.Inventory {
	public class InventoryController {
        public List<IInventoryCell> Cells { get; private set; }


        public InventoryController() {

        }

        public void Initialize(int size, Func<IInventoryCell> createCellFunc) {
            Cells = new List<IInventoryCell>(size);
            for (int i = 0; i < size; i++) {
                Cells.Add(createCellFunc());
            }
        }

        public void AddItem(int index, IInventoryItem inventoryItem) {
            Cells[index].AddItem(inventoryItem);
        }

        public void RemoveItem(int index) {
            Cells[index].RemoveItem();
        }
    }

    public interface IInventoryCell {
        IInventoryItem Item { get; }
        bool HasItem { get; }
        void AddItem(IInventoryItem inventoryItem);
        void RemoveItem();
    }

    public interface IInventoryItem {

    }
}