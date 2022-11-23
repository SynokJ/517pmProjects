using UnityEngine;

public class Interactable : MonoBehaviour, I_Interactable
{
    [SerializeField] private string _reaction;

    public void OnActive()
    {
        this.gameObject.layer = default;
    }

    public string OnInteract() => _reaction;
}