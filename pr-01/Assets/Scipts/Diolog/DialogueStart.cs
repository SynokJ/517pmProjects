using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [Header("Player Speach paramters: ")]
    [SerializeField] private SpeachWindow _player;
    [SerializeField] private AnswersAnimation _playerAnswers;

    private SpeachWindow _other;
    private bool _isStarted;

    private Speach _playerSpeach;
    private Speach _otherSpeach;

    private string _playerText;
    private string _otherText;

    public void StartDialogue(SpeachWindow other, SpeachSO speaches)
    {
        _other = other;

        InitSpeaches(speaches);
        ShowInitSpeaches();
    }

    public void EndDialogue()
    {
        if (_other == null)
            return;

        _isStarted = false;

        _playerAnswers.HideDialogue();
        _other.HideMessage();
        _other = null;
    }

    public bool IsDialogueActive() => _isStarted;

    private void InitSpeaches(SpeachSO speaches)
    {
        _playerSpeach = new Speach(speaches.playerInitSpeach, speaches.playerSpeaches);
        _otherSpeach = new Speach(speaches.enemyInitSpeach, speaches.enemySpeachs);
    }

    private void ShowInitSpeaches()
    {
        StartCoroutine(OnShown(_playerSpeach.GetInitPhrase(), _otherSpeach.GetInitPhrase()));
    }

    private IEnumerator OnShown(string playerMessage, string otherMessage)
    {
        _player.InitMessage(playerMessage);

        yield return new WaitUntil(() => !_player.isTyping);
        _other.InitMessage(otherMessage);
        _517pm.Debugger.CustomDebugger.ItWorks();

        if (_isStarted)
            yield break;

        yield return new WaitUntil(() => !_other.isTyping);
        _playerAnswers.ShowDialogue();
        _isStarted = true;
    }

    public void AnswerByIndexIsSelected(int index)
    {
        if (CanTakeThisAnswer(index))
            StartCoroutine(OnShown(_playerText, _otherText));
    }

    public bool CanTakeThisAnswer(int id)
        => _playerSpeach.TryGetSpeachByIndex(id, out _playerText) && _otherSpeach.TryGetSpeachByIndex(id, out _otherText);
}