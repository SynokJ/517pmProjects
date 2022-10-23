using UnityEngine;

public class TestCollectable : MonoBehaviour, ICollectable
{

    public InventoryItem.InventoryItemDelegate OnCollect() => TestAction;

    private void TestAction()
    {
        Debug.Log("Hello World");
    }
}
