using System.Collections;
using UnityEngine;
using TMPro;

public class DialogShow : MonoBehaviour
{

    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private GameObject _dialogAnswerPanel;
    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private TMP_Text _message;

    private Animator _answersAnim;
    private Animator _inventoryAnim;

    private void Start()
    {
        _answersAnim = _dialogAnswerPanel.GetComponent<Animator>();
        _inventoryAnim = _inventoryPanel.GetComponent<Animator>();
    }

    public void ShowDialogue()
    {
        _dialogueWindow.SetActive(!_dialogueWindow.activeSelf);

    }

    public void InitMessage(string message)
    {
        _message.text = default;
        StartCoroutine(TypeMessage(message));
    }

    private IEnumerator ShowAswers()
    {
        _inventoryAnim.SetTrigger("on_hide");
        _answersAnim.SetTrigger("on_show");

        yield return new WaitForSeconds(1.0f);
        _dialogAnswerPanel.SetActive(!_dialogAnswerPanel.activeSelf);
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
