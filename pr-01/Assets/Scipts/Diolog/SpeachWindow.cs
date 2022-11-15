using System.Collections;
using UnityEngine;
using TMPro;

public class SpeachWindow : MonoBehaviour
{

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TMP_Text _message;

    public bool isTyping { get; private set; }

    public void InitMessage(string message)
    {
        _dialogueWindow.SetActive(!_dialogueWindow.activeSelf);
        _message.text = default;
        isTyping = false;
        StartCoroutine(TypeMessage(message));
    }

    public void HideMessage()
    {
        _dialogueWindow.SetActive(false);
        _message.text = default;
    }

    private IEnumerator TypeMessage(string message)
    {
        for (int i = 0; i < message.Length; ++i)
        {
            _message.text += message[i];
            yield return null;
        }
        isTyping = false;
    }

    public bool IsPanelActive() => _dialogueWindow.activeSelf;
}
