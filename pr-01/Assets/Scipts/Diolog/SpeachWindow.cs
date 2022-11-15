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
        ShowMessage();
        StartCoroutine(TypeMessage(message));
    }

    public void ShowMessage()
    {
        _dialogueWindow.SetActive(true);
        _message.text = default;
    }

    public void HideMessage()
    {
        _dialogueWindow.SetActive(false);
        _message.text = default;
    }

    private IEnumerator TypeMessage(string message)
    {
        isTyping = true;
        for (int i = 0; i < message.Length; ++i)
        {
            _message.text += message[i];
            yield return null;
        }
        isTyping = false;
    }

    public bool IsPanelActive() => _dialogueWindow.activeSelf;
}
