using UnityEngine;

public class Interactable : MonoBehaviour, I_Interactable
{
    [SerializeField] private string _reaction;

    public string OnInteract() => _reaction;
}