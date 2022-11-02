using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    [SerializeField] private DialogueShow _player;
    private DialogueShow _other;

    private Speach _playerSpeach;
    private Speach _otherSpeach;

    public void StartDialogue(DialogueShow other, SpeachSO speaches)
    {
        Debug.Log("Dialogue is started");

        _other = other;
        _playerSpeach = new Speach(speaches.playerInitSpeach, speaches.playerSpeaches);
        _otherSpeach = new Speach(speaches.enemyInitSpeach, speaches.enemySpeachs);

        _other.InitMessage(_otherSpeach.GetInitPhrase());
        _player.InitMessage(_playerSpeach.GetInitPhrase());
        _player.ShowDialogue();
    }
}
