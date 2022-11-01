using UnityEngine;

public class TestCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private CircleCollider2D _circleCollider;

    public InventoryItem.InventoryItemDelegate OnCollect()
    {
        OnHide();
        return TestAction;
    }
    private void TestAction()
    {
        Debug.Log("Hello World");
    }

    public void OnHide()
    {
        _renderer.enabled = false;
        _circleCollider.enabled = false;
    }

    public void OnShow()
    {
        _renderer.enabled = true;
        _circleCollider.enabled = true;
    }
}
