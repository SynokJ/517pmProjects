using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private InventoryShow _show;

    private List<InventoryItem> _items = new List<InventoryItem>();
    private const int _INVENTORY_MAX_SIZE = 10;

    public void AddInventoryItem(InventoryItem item)
    {
        if (!_items.Contains(item) && _items.Count <= 10)
        {
            _items.Add(item);
            _show.ShowNewItem(item);
        }
    }

    public Sprite GetSpriteByIndex(int id)
    {
        if (_items == null || id >= _items.Count)
            return null;

        return _items[id].sprite;
    }
}
