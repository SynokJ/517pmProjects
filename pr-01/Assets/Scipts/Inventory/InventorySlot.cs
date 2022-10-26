using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [SerializeField] private Image _image;
    public bool isAvailable;

    public void ResetSlot()
    {
        _image = null;
    }

    public void InitSlot(Sprite sprite)
    {
        _image.sprite = sprite;
        isAvailable = true;
    }
}