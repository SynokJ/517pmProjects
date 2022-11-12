using System.Collections;
using UnityEngine;

public class AnswersAnimation : MonoBehaviour
{
    [Header("Answer Parameters: ")]
    [SerializeField] private GameObject _answersPanel;
    [SerializeField] private Animator _answersAnim;

    public bool isMoving { get; private set; }

    #region Show and Hide
    public void ShowDialogue()
    {
        isMoving = true;
        StartCoroutine(ShowAnswersPanel());
    }

    public void HideDialogue()
    {
        StartCoroutine(HideAnswersPanel());
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
        isMoving = false;
    }
    #endregion
}
