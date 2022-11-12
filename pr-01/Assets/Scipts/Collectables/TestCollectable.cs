using UnityEngine;

public class TestCollectable : MonoBehaviour, ICollectable
{
    [Header("Collectable Parameters: ")]
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private CircleCollider2D _circleCollider;

    public InventoryItem.InventoryItemDelegate OnCollect()
    {
        OnHide();
        return TestAction;
    }

    private void TestAction()
        => _517pm.Debugger.CustomDebugger.TheActionIsWorking(true);

    #region Hide And Show
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
    #endregion
}
