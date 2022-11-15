public interface ICollectable 
{
    InventoryItem.InventoryItemDelegate OnCollect();
    void OnHide();
    void OnShow();
}
