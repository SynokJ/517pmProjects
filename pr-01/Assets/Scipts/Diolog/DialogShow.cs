using System.Collections;
using UnityEngine;
using TMPro;

public class DialogShow : MonoBehaviour
{

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TMP_Text _message;

    public void ShowDialogue()
    {
        _dialogueWindow.SetActive(true);
    }

    public void HideDialogue()
    {
        _dialogueWindow.SetActive(false);
    }

    public void InitMessage(string message)
    {
        _message.text = default;
        StartCoroutine(TypeMessage(message));
    }

    private IEnumerator TypeMessage(string message)
    {
        if (message == null)
        {
            Debug.Log("No MEssage");
            yield break;
        }

        if (_message == null)
        {
            Debug.Log("No TMP Message");
            yield break;
        }


        for (int i = 0; i < message.Length; ++i)
        {
            _message.text += message[i];
            yield return null;
        }
    }
}
