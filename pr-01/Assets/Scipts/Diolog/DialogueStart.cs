using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField] private SpeachWindow _player;
    [SerializeField] private AnswersWindow _playerAnswers;

    private SpeachWindow _other;
    private bool _isActive;

    private Speach _playerSpeach;
    private Speach _otherSpeach;

    public void StartDialogue(SpeachWindow other, SpeachSO speaches)
    {
        _isActive = true;
        _other = other;

        InitSpeaches(speaches);
        ShowInitSpeaches();
    }

    public void EndDialogue()
    {
        if (_other == null)
            return;

        _isActive = false;

        _playerAnswers.HideDialogue();
        _other.HideMessage();
        _other = null;
    }

    public bool IsDialogueActive() => _isActive;

    private void InitSpeaches(SpeachSO speaches)
    {
        _playerSpeach = new Speach(speaches.playerInitSpeach, speaches.playerSpeaches);
        _otherSpeach = new Speach(speaches.enemyInitSpeach, speaches.enemySpeachs);
    }

    private void ShowInitSpeaches()
    {
        _player.InitMessage(_playerSpeach.GetInitPhrase());
        StartCoroutine(OnShown());
    }

    private IEnumerator OnShown()
    {
        yield return new WaitUntil(() => !_player.isTyping);
        _other.InitMessage(_otherSpeach.GetInitPhrase());

        yield return new WaitUntil(() => !_other.isTyping);
        _playerAnswers.ShowDialogue();

        yield return new WaitUntil(() => !_playerAnswers.isMoving);
        _player.HideMessage();
    }
}