using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rustem.Uitls
{

    public static class CustomUtils
    {

        public static bool IsPointerOverUI(int touchId) => EventSystem.current.IsPointerOverGameObject(touchId);

        public static void GetCameraWorldSize(out float width, out float height)
        {
            Camera camera = Camera.main;
            height = 2.0f * camera.orthographicSize;
            width = height * camera.aspect;
        }

        public static GameObject GetTouchedUI_Item(Touch firstTouch)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(firstTouch.position.x, firstTouch.position.y);

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            if (results.Count > 0)
                return results[0].gameObject;

            return null;
        }
    }
}