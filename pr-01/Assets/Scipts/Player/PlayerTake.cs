using UnityEngine;

public class PlayerTake : MonoBehaviour
{
    [Header("Take Parameters: ")]
    [SerializeField] private PlayerWalk _walk;
    [SerializeField] private Inventory _inventory;

    [Header("Dialogue Parameters: ")]
    [SerializeField] private DialogueStart _dialogueStart;
    [SerializeField] private SpeachWindow _playerSpeach;

    private const float _TAKE_RADIUS = 1.0f;
    private SpriteRenderer _spriteRenderer;

    private ICollectable _collectable;
    private ISpeakable _speakable;
    private I_Interactable _interactable;

    #region Subscription On Event
    private void OnEnable()
    {
        _walk.OnArrived += OnDestinationReached;
    }

    private void OnDisable()
    {
        _walk.OnArrived -= OnDestinationReached;
    }
    #endregion

    /// <summary>
    /// Weird Method == Bolachka :(
    /// PLS HEAL ME RIGHT NOW!!!
    /// </summary>
    public void OnDestinationReached()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, _TAKE_RADIUS);

        foreach (Collider2D hit in hits)
        {
            if (IsCollectable(hit.gameObject))
            {
                _spriteRenderer = hit.GetComponentInChildren<SpriteRenderer>();
                if (_collectable != null)
                    _inventory.AddInventoryItem(new InventoryItem(_collectable.OnCollect(), _spriteRenderer.sprite));
                break;
            }
            else if (IsSpeakable(hit.gameObject))
            {
                var dialogue = hit.GetComponent<SpeachWindow>();
                _dialogueStart.StartDialogue(dialogue, _speakable.StartDialogue());
                break;
            }
            else if (IsInteractable(hit.gameObject))
            {
                _playerSpeach.InitMessage(_interactable.OnInteract());
                break;
            }
            else if (_playerSpeach.IsPanelActive() || _dialogueStart.IsDialogueActive())
            {
                _playerSpeach.HideMessage();
                _dialogueStart.EndDialogue();
            }
        }
    }

    private bool IsCollectable(GameObject hit)
    {
        _collectable = hit.GetComponent<ICollectable>();
        return _collectable != null;
    }

    private bool IsSpeakable(GameObject hit)
    {
        _speakable = hit.GetComponentInChildren<ISpeakable>();
        return _speakable != null;
    }

    private bool IsInteractable(GameObject hit)
    {
        _interactable = hit.GetComponentInChildren<I_Interactable>();
        return _interactable != null;
    }
}
