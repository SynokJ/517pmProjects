using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUse : MonoBehaviour
{

    private Camera _camera;
    private Touch _firstTouch;

    private Vector2 _originPosition;
    private GameObject _touchedItem;
    private Vector2 _positionOffset;

    private InventorySlot _slot;

    private void Start()
    {
        _camera = Camera.main;
    }


    void Update()
    {
        if (Input.touchCount > 0)
        {
            _firstTouch = Input.GetTouch(0);

            if (_firstTouch.phase == TouchPhase.Began && EventSystem.current.IsPointerOverGameObject(_firstTouch.fingerId))
                InitTouchedItem();
            else if (_firstTouch.phase == TouchPhase.Moved && _touchedItem && EventSystem.current.IsPointerOverGameObject(_firstTouch.fingerId))
                _touchedItem.transform.position = _firstTouch.position + _positionOffset;
            else if (_firstTouch.phase == TouchPhase.Ended && _touchedItem)
                _touchedItem.transform.position = _originPosition;
        }
    }

    private void InitTouchedItem()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = _firstTouch.position;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (var result in results)
            if (IsAvailabelToUse(result.gameObject))
            {
                _touchedItem = result.gameObject;
                _originPosition = result.gameObject.transform.position;
                _positionOffset = (Vector2)_slot.transform.position - _firstTouch.position;
                break;
            }
    }

    private bool IsAvailabelToUse(GameObject obj)
    {
        _slot = obj.GetComponent<InventorySlot>();
        return _slot != null && _slot.isAvailable;
    }
}
