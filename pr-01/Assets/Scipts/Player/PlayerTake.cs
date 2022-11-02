using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTake : MonoBehaviour
{

    [SerializeField] private PlayerWalk _walk;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private DialogueStart _dialogueStart;

    private const float _TAKE_RADIUS = 1.0f;
    private ICollectable _collectable;
    private SpriteRenderer _spriteRenderer;
    private ISpeakable _speakable;

    private void Start()
    {
        _walk.OnArrived += OnTakeItem;
    }

    public void OnTakeItem()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, _TAKE_RADIUS);

        foreach (Collider2D hit in hits)
        {
            _collectable = hit.GetComponent<ICollectable>();
            _spriteRenderer = hit.GetComponentInChildren<SpriteRenderer>();
            if (_collectable != null)
                _inventory.AddInventoryItem(new InventoryItem(_collectable.OnCollect(), _spriteRenderer.sprite));

            _speakable = hit.GetComponentInChildren<ISpeakable>();
            if (_speakable != null)
            {
                var dialogue = hit.GetComponent<DialogueShow>();
                _dialogueStart.StartDialogue(dialogue, _speakable.StartDialogue());
            }
        }
    }
}
