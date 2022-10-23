public class InventoryItem
{
    public UnityEngine.Sprite sprite;
    public delegate void InventoryItemDelegate();
    private InventoryItemDelegate OnAction = default;

    public InventoryItem(InventoryItemDelegate action, UnityEngine.Sprite sprite)
    {
        OnAction = action;
        this.sprite = sprite;
    }

    public void UseInventoryItem()
    {
        OnAction?.Invoke();
    }
}
