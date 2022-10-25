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
        StartCoroutine(ShowAnswers());
    }

    public void InitMessage(string message)
    {
        _message.text = default;
        StartCoroutine(TypeMessage(message));
    }

    private IEnumerator ShowAnswers()
    {
        string res = default;
        ShowInteractionPanel(_answersAnim, _dialogAnswerPanel, ref res);
        ShowInteractionPanel(_inventoryAnim, _inventoryPanel, ref res);

        yield return new WaitForSeconds(GetTheLongerClip());

        Debug.Log(res);

        if (res.Equals(_dialogAnswerPanel.name))
            _dialogAnswerPanel.SetActive(false);
        else if (res.Equals(_inventoryPanel.name))
            _inventoryPanel.SetActive(false);
    }

    private void ShowInteractionPanel(Animator anim, GameObject panel, ref string res)
    {
        if (panel.activeSelf)
        {
            anim.SetTrigger("on_hide");
            res = panel.name;
        }
        else
        {
            panel.SetActive(true);
            anim.SetTrigger("on_show");
        }
    }

    private float GetTheLongerClip() =>
        Mathf.Max(_inventoryAnim.GetCurrentAnimatorStateInfo(0).length, _answersAnim.GetCurrentAnimatorStateInfo(0).length);

    private IEnumerator TypeMessage(string message)
    {

        for (int i = 0; i < message.Length; ++i)
        {
            _message.text += message[i];
            yield return null;
        }
    }
}
