using UnityEngine;

public class Speakable : MonoBehaviour, ISpeakable
{
    [SerializeField] private SpeachSO _speachSO;

    public SpeachSO StartDialogue()
    {
        return _speachSO;
    }
}
