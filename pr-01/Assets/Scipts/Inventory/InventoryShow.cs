using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryShow : MonoBehaviour
{

    [SerializeField] private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

    private int _lastIndex = 0;
    private const int _INVENTORY_MAX_SIZE = 10;

    public void ShowNewItem(InventoryItem items)
    {
        if (_lastIndex >= _INVENTORY_MAX_SIZE)
            return;

        _inventorySlots[_lastIndex].InitSlot(items.sprite);
        _lastIndex++;
    }
}
