using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueShow : MonoBehaviour
{

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private GameObject _answersPanel;
    [SerializeField] private TMP_Text _message;

    [SerializeField] private Animator _answersAnim;

    public void ShowDialogue()
    {
        if (!_answersPanel.activeSelf)
            StartCoroutine(ShowAnswersPanel());
        else
            StartCoroutine(HideAnswersPanel());
    }

    public void InitMessage(string message)
    {
        _dialogueWindow.SetActive(!_dialogueWindow.activeSelf);
        _message.text = default;
        StartCoroutine(TypeMessage(message));
    }

    private IEnumerator HideAnswersPanel()
    {
        _answersAnim.SetTrigger("on_hide");
        yield return new WaitForSeconds(_answersAnim.GetCurrentAnimatorStateInfo(0).length);
        _answersPanel.SetActive(false);
    }

    private IEnumerator ShowAnswersPanel()
    {
        _answersPanel.SetActive(true);
        _answersAnim.SetTrigger("on_show");
        yield return new WaitForSeconds(_answersAnim.GetCurrentAnimatorStateInfo(0).length);
    }

    private IEnumerator TypeMessage(string message)
    {
        for (int i = 0; i < message.Length; ++i)
        {
            _message.text += message[i];
            yield return null;
        }
    }
}
